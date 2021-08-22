using SchemaTypist.Config;
using SchemaTypist.Language;
using SchemaTypist.Schemata.Dto;
using SchemaTypist.SqlVendors;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Model
{
    static class ModelConverterService
    {
        public static Dictionary<string, TabularStructure> Convert(IEnumerable<ColumnsDto> fromColumns, CodeGenConfig config)
        {
            //Convert
            var tableStructureMap = new Dictionary<string, TabularStructure>();
            foreach (var col in fromColumns)
            {
                var key = $"{col.TableCatalog}.{col.TableSchema}.{col.TableName}";
                if (!tableStructureMap.ContainsKey(key)) tableStructureMap.Add(key,
                    new()
                    {
                        SqlCatalog = col.TableCatalog,
                        SqlSchema = col.TableSchema,
                        SqlName = col.TableName,
                        Catalog = LanguageService.ConvertCatalogName(col.TableCatalog, config),
                        Schema = LanguageService.ConvertSchemaName(col.TableSchema, config),
                        Name = LanguageService.ConvertTableName(col.TableName, config),
                        TabularStructureType = TabularType.Table,
                        Columns = new List<ColumnMetadata>(),
                        Config = config
                    });

                if (tableStructureMap[key].Columns.Any(c => c.SqlName == col.ColumnName)) continue;

                tableStructureMap[key].Columns.Add(new()
                {
                    SqlName = col.ColumnName,
                    SqlDataType = col.DataType,
                    Name = LanguageService.ConvertColumnName(col.ColumnName, config),
                    IsNullable = col.IsNullable == "Yes",
                    DataType = DetermineDotNetDataType(col.DataType, col.IsNullable == "Yes", config)
                });
            }
            return tableStructureMap;
        }

        private static string DetermineDotNetDataType(string sqlDataType, bool isNullable, CodeGenConfig config)
        {
            return Vendors.GetSqlDialect(config.Vendor).DetermineDotNetDataType(sqlDataType, isNullable);
        }
    }
}
