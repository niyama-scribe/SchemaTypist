using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Core.Schemata.Mapping
{
    static partial class InformationSchema
    {
        public static partial class Columns
        {
            public static TableDefinition Table => new();

            public partial class TableDefinition : TabularDefinition
            {
                private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                public TableDefinition() : base("information_schema.columns")
                {
                    _columns.Add(Constants.TableCatalog, new ColumnDefinition(Constants.TableCatalog, this));
                    _columns.Add(Constants.TableSchema, new ColumnDefinition(Constants.TableSchema, this));
                    _columns.Add(Constants.TableName, new ColumnDefinition(Constants.TableName, this));
                    _columns.Add(Constants.OrdinalPosition, new ColumnDefinition(Constants.OrdinalPosition, this));
                    _columns.Add(Constants.ColumnName, new ColumnDefinition(Constants.ColumnName, this));
                    _columns.Add(Constants.DataType, new ColumnDefinition(Constants.DataType, this));
                    _columns.Add(Constants.CharacterMaximumLength, new ColumnDefinition(Constants.CharacterMaximumLength, this));
                    _columns.Add(Constants.NumericPrecision, new ColumnDefinition(Constants.NumericPrecision, this));
                    _columns.Add(Constants.NumericScale, new ColumnDefinition(Constants.NumericScale, this));
                    _columns.Add(Constants.IsNullable, new ColumnDefinition(Constants.IsNullable, this));

                    /*TableCatalog = new ColumnDefinition(Constants.TableCatalog, this);
                    TableSchema = new ColumnDefinition(Constants.TableSchema, this);
                    TableName = new ColumnDefinition(Constants.TableName, this);
                    OrdinalPosition = new ColumnDefinition(Constants.OrdinalPosition, this);
                    ColumnName = new ColumnDefinition(Constants.ColumnName, this);
                    DataType = new ColumnDefinition(Constants.DataType, this);
                    CharacterMaximumLength = new ColumnDefinition(Constants.CharacterMaximumLength, this);
                    NumericPrecision = new ColumnDefinition(Constants.NumericPrecision, this);
                    NumericScale = new ColumnDefinition(Constants.NumericScale, this);
                    IsNullable = new ColumnDefinition(Constants.IsNullable, this);*/

                }

                public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

                public ColumnDefinition TableCatalog => _columns[Constants.TableCatalog];
                public ColumnDefinition TableSchema => _columns[Constants.TableSchema];
                public ColumnDefinition TableName => _columns[Constants.TableName];
                public ColumnDefinition OrdinalPosition => _columns[Constants.OrdinalPosition];
                public ColumnDefinition ColumnName => _columns[Constants.ColumnName];
                public ColumnDefinition DataType => _columns[Constants.DataType];
                public ColumnDefinition CharacterMaximumLength => _columns[Constants.CharacterMaximumLength];
                public ColumnDefinition NumericPrecision => _columns[Constants.NumericPrecision];
                public ColumnDefinition NumericScale => _columns[Constants.NumericScale];
                public ColumnDefinition IsNullable => _columns[Constants.IsNullable];

                public IEnumerable<ColumnDefinition> Star => _columns.Values;
            }

            static partial class Constants
            {
                public const string TableCatalog = "table_catalog";
                public const string TableSchema = "table_schema";
                public const string TableName = "table_name";
                public const string OrdinalPosition = "ordinal_position";
                public const string ColumnName = "column_name";
                public const string DataType = "data_type";
                public const string CharacterMaximumLength = "character_maximum_length";
                public const string NumericPrecision = "numeric_precision";
                public const string NumericScale = "numeric_scale";
                public const string IsNullable = "is_nullable";
            }

            public static partial class QueryResultsMapper
            {
                private static Dictionary<string, string> columnMap = new()
                {
                    {Constants.TableCatalog, nameof(ColumnsDto.TableCatalog) },
                    {Constants.TableSchema, nameof(ColumnsDto.TableSchema) },
                    {Constants.TableName, nameof(ColumnsDto.TableName) },
                    {Constants.OrdinalPosition, nameof(ColumnsDto.OrdinalPosition) },
                    {Constants.ColumnName, nameof(ColumnsDto.ColumnName) },
                    {Constants.DataType, nameof(ColumnsDto.DataType) },
                    {Constants.CharacterMaximumLength, nameof(ColumnsDto.CharacterMaxLength) },
                    {Constants.NumericPrecision, nameof(ColumnsDto.NumericPrecision) },
                    {Constants.NumericScale, nameof(ColumnsDto.NumericScale) },
                    {Constants.IsNullable, nameof(ColumnsDto.IsNullable) }

                };

                static Func<Type, string, PropertyInfo> GetMapperFunc()
                {
                    var mapper = new Func<Type, string, PropertyInfo>((t, columnName) =>
                    {
                        if (columnMap.ContainsKey(columnName)) return t.GetProperty(columnMap[columnName]);
                        return t.GetProperty(columnName);
                    }
                    );
                    return mapper;
                }

                public static CustomPropertyTypeMap GetMapper()
                {
                    return new CustomPropertyTypeMap(typeof(ColumnsDto), GetMapperFunc());
                }
            }

        }
    }
}
