using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Language;
using SchemaTypist.Core.Model;
using SchemaTypist.Core.Naming;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.Core.SqlVendors;

namespace SchemaTypist.Core.Schemata
{
    internal class SchemataConverterService : ISchemataConverterService
    {
        private readonly INamingService _namingService;
        private readonly ISqlVendorService _sqlVendor;

        public SchemataConverterService(INamingService namingService, ISqlVendorService sqlVendor)
        {
            _namingService = namingService;
            _sqlVendor = sqlVendor;
        }
        public Dictionary<string, TabularStructure> Convert(IEnumerable<ColumnsDto> fromColumns, CodeGenConfig config)
        {
            //Convert
            var includeRegex = string.IsNullOrWhiteSpace(config.Include) ? null : 
                config.Include?.Split(',').Select(s => new Regex(s.Replace(".", @"\.").Replace("*", ".*")));
            var excludeRegex = string.IsNullOrWhiteSpace(config.Exclude) ? null : 
                config.Exclude?.Split(',').Select(s => new Regex(s.Replace(".", @"\.").Replace("*", ".*")));
            var tableStructureMap = new Dictionary<string, TabularStructure>();
            foreach (var col in fromColumns)
            {
                var key = $"{col.TableCatalog}.{col.TableSchema}.{col.TableName}";
                if (excludeRegex!=null && excludeRegex.Any(r => r.IsMatch(key))) continue;
                if (includeRegex != null && includeRegex.All(r => !r.IsMatch(key))) continue;
                if (!tableStructureMap.ContainsKey(key)) tableStructureMap.Add(key,
                    new()
                    {
                        SqlCatalog = col.TableCatalog,
                        SqlSchema = col.TableSchema,
                        SqlName = col.TableName,
                        TabularStructureType = TabularType.Table,
                        Columns = new List<ColumnMetadata>()
                    });

                var tabStructure = tableStructureMap[key];
                tabStructure.Catalog = _namingService.ConvertCatalogName(col.TableCatalog, config);
                tabStructure.Schema = _namingService.ConvertSchemaName(col.TableSchema, config,
                    tabStructure.Catalog);
                tabStructure.Name = _namingService.ConvertTableName(col.TableName, config, tabStructure.Schema);


                tabStructure.SqlQualifiedName = _sqlVendor.BuildQualifiedName(tabStructure, config);

                if (tabStructure.Columns.Any(c => c.SqlName == col.ColumnName)) continue;

                ColumnMetadata columnMetadata = new()
                {
                    SqlName = col.ColumnName,
                    SqlDataType = col.DataType,
                    Name = _namingService.ConvertColumnName(col.ColumnName, config,
                        new HashSet<string>() {tabStructure.Name}),
                    IsNullable = string.Equals(col.IsNullable, "Yes", StringComparison.InvariantCultureIgnoreCase),
                    DataType = DetermineDotNetDataType(col.DataType,
                        string.Equals(col.IsNullable, "Yes", StringComparison.InvariantCultureIgnoreCase), config),
                };

                UpdateDefaultValue(columnMetadata, col.ColumnDefault, config);

                tabStructure.Columns.Add(columnMetadata);
            }
            return tableStructureMap;
        }

        private void UpdateDefaultValue(ColumnMetadata columnMetadata, string columnDefault, CodeGenConfig config)
        {
            var defaultValue = config.UseSqlDefaultValue ? 
                _sqlVendor.DetermineDefaultValue(columnDefault, columnMetadata.DataType, config) : null;
            

            //Default value can be null, "null", blank or non-null-literal-value
            if (string.IsNullOrWhiteSpace(defaultValue)) defaultValue = null;

            //Handle language vagaries
            /*
             * PROPERTY INITIALIZATION
             *
             * If db column has non-null default value
             *      Initialize property to non-null-default-value
             * Else
             *      if mapped type is reference type and db column is not nullable
             *          if using nullable references
             *            Initialize property to "default!"
             */

            if (defaultValue is null or "null")
            {
                defaultValue = config.TargetLanguageVersion.ToLower() == "default"  &&
                               config.UseNullableRefTypes &&
                               Languages.CSharp.IsReferenceType(columnMetadata.DataType) &&
                               !Languages.CSharp.IsNullable(columnMetadata.DataType)
                               
                    ? "default!"
                    : null;
            }
                


            columnMetadata.DefaultValue = defaultValue;
        }

        private string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config)
        {
            return _sqlVendor.DetermineDotNetDataType(sqlDataType, isNullable, config);
        }
    }

    public interface ISchemataConverterService
    {
        Dictionary<string, TabularStructure> Convert(IEnumerable<ColumnsDto> fromColumns, CodeGenConfig config);
    }
}