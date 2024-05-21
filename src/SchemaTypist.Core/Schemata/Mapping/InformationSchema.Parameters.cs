using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper;
using SchemaTypist.Core.Schemata.Dto;
using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Core.Schemata.Mapping
{
    internal static partial class InformationSchema
    {
        public static class Parameters
        {
            public static TableDefinition Table => new();

            public class TableDefinition : TabularDefinition
            {
                private readonly IDictionary<string, ColumnDefinition> _columns =
                    new Dictionary<string, ColumnDefinition>();

                public TableDefinition() : base("information_schema.parameters")
                {
                    _columns.Add(Constants.SpecificCatalog, new ColumnDefinition(Constants.SpecificCatalog, this));
                    _columns.Add(Constants.SpecificSchema, new ColumnDefinition(Constants.SpecificSchema, this));
                    _columns.Add(Constants.SpecificName, new ColumnDefinition(Constants.SpecificName, this));
                    _columns.Add(Constants.OrdinalPosition, new ColumnDefinition(Constants.OrdinalPosition, this));
                    _columns.Add(Constants.ParameterName, new ColumnDefinition(Constants.ParameterName, this));
                    _columns.Add(Constants.DataType, new ColumnDefinition(Constants.DataType, this));
                    _columns.Add(Constants.CharacterMaximumLength,
                        new ColumnDefinition(Constants.CharacterMaximumLength, this));
                    _columns.Add(Constants.NumericPrecision, new ColumnDefinition(Constants.NumericPrecision, this));
                    _columns.Add(Constants.NumericScale, new ColumnDefinition(Constants.NumericScale, this));
                    _columns.Add(Constants.ParameterMode, new ColumnDefinition(Constants.ParameterMode, this));
                    _columns.Add(Constants.IsNullable, new ColumnDefinition(Constants.IsNullable, this));
                    _columns.Add(Constants.Default, new ColumnDefinition(Constants.Default, this));
                }

                public ColumnDefinition SpecificCatalog => _columns[Constants.SpecificCatalog];
                public ColumnDefinition SpecificSchema => _columns[Constants.SpecificSchema];
                public ColumnDefinition SpecificName => _columns[Constants.SpecificName];
                public ColumnDefinition OrdinalPosition => _columns[Constants.OrdinalPosition];
                public ColumnDefinition ParameterName => _columns[Constants.ParameterName];
                public ColumnDefinition DataType => _columns[Constants.DataType];
                public ColumnDefinition CharacterMaximumLength => _columns[Constants.CharacterMaximumLength];
                public ColumnDefinition NumericPrecision => _columns[Constants.NumericPrecision];
                public ColumnDefinition NumericScale => _columns[Constants.NumericScale];
                public ColumnDefinition ParameterMode => _columns[Constants.ParameterMode];
                public ColumnDefinition IsNullable => _columns[Constants.IsNullable];
                public ColumnDefinition Default => _columns[Constants.Default];

                public IEnumerable<ColumnDefinition> Star => _columns.Values;

                public TableDefinition As(string alias)
                {
                    return base.As<TableDefinition>(alias);
                }
            }

            private static class Constants
            {
                public const string SpecificCatalog = "specific_catalog";
                public const string SpecificSchema = "specific_schema";
                public const string SpecificName = "specific_name";
                public const string OrdinalPosition = "ordinal_position";
                public const string ParameterName = "parameter_name";
                public const string DataType = "data_type";
                public const string CharacterMaximumLength = "character_maximum_length";
                public const string NumericPrecision = "numeric_precision";
                public const string NumericScale = "numeric_scale";
                public const string ParameterMode = "parameter_mode";
                public const string IsNullable = "is_nullable";
                public const string Default = "default";
            }

            public static class QueryResultsMapper
            {
                private static readonly Dictionary<string, string> columnMap = new()
                {
                    {Constants.OrdinalPosition, nameof(ParametersDto.OrdinalPosition)},
                    {Constants.ParameterName, nameof(ParametersDto.ParameterName)},
                    {Constants.DataType, nameof(ParametersDto.DataType)},
                    {Constants.CharacterMaximumLength, nameof(ParametersDto.CharacterMaximumLength)},
                    {Constants.NumericPrecision, nameof(ParametersDto.NumericPrecision)},
                    {Constants.NumericScale, nameof(ParametersDto.NumericScale)},
                    {Constants.ParameterMode, nameof(ParametersDto.ParameterMode)},
                    {Constants.IsNullable, nameof(ParametersDto.IsNullable)},
                    {Constants.Default, nameof(ParametersDto.Default)}
                };

                private static Func<Type, string, PropertyInfo> GetMapperFunc()
                {
                    var mapper = new Func<Type, string, PropertyInfo>((t, columnName) =>
                        t.GetProperty(columnMap.TryGetValue(columnName, out var value) ? value : columnName));
                    return mapper;
                }

                public static CustomPropertyTypeMap GetMapper()
                {
                    return new CustomPropertyTypeMap(typeof(RoutinesDto), GetMapperFunc());
                }
            }
        }
    }
}