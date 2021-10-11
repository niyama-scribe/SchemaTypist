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
                public TableDefinition() : base("INFORMATION_SCHEMA.COLUMNS")
                {
                    TableCatalog = new ColumnDefinition(Constants.TableCatalog, this);
                    TableSchema = new ColumnDefinition(Constants.TableSchema, this);
                    TableName = new ColumnDefinition(Constants.TableName, this);
                    OrdinalPosition = new ColumnDefinition(Constants.OrdinalPosition, this);
                    ColumnName = new ColumnDefinition(Constants.ColumnName, this);
                    DataType = new ColumnDefinition(Constants.DataType, this);
                    CharacterMaximumLength = new ColumnDefinition(Constants.CharacterMaximumLength, this);
                    NumericPrecision = new ColumnDefinition(Constants.NumericPrecision, this);
                    NumericScale = new ColumnDefinition(Constants.NumericScale, this);
                    IsNullable = new ColumnDefinition(Constants.IsNullable, this);

                }

                public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

                public ColumnDefinition TableCatalog { get; private set; }
                public ColumnDefinition TableSchema { get; private set; }
                public ColumnDefinition TableName { get; private set; }
                public ColumnDefinition OrdinalPosition { get; private set; }
                public ColumnDefinition ColumnName { get; private set; }
                public ColumnDefinition DataType { get; private set; }
                public ColumnDefinition CharacterMaximumLength { get; private set; }
                public ColumnDefinition NumericPrecision { get; private set; }
                public ColumnDefinition NumericScale { get; private set; }
                public ColumnDefinition IsNullable { get; private set; }
            }

            static partial class Constants
            {
                public const string TableCatalog = "TABLE_CATALOG";
                public const string TableSchema = "TABLE_SCHEMA";
                public const string TableName = "TABLE_NAME";
                public const string OrdinalPosition = "ORDINAL_POSITION";
                public const string ColumnName = "COLUMN_NAME";
                public const string DataType = "DATA_TYPE";
                public const string CharacterMaximumLength = "CHARACTER_MAXIMUM_LENGTH";
                public const string NumericPrecision = "NUMERIC_PRECISION";
                public const string NumericScale = "NUMERIC_SCALE";
                public const string IsNullable = "IS_NULLABLE";
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
