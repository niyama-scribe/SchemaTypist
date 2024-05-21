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
        public static partial class Routines
        {
            public static TableDefinition Table => new();

            public class TableDefinition : TabularDefinition
            {
                private readonly IDictionary<string, ColumnDefinition> _columns =
                    new Dictionary<string, ColumnDefinition>();

                public TableDefinition() : base("information_schema.routines")
                {
                    _columns.Add(Constants.SpecificCatalog, new ColumnDefinition(Constants.SpecificCatalog, this));
                    _columns.Add(Constants.SpecificSchema, new ColumnDefinition(Constants.SpecificSchema, this));
                    _columns.Add(Constants.SpecificName, new ColumnDefinition(Constants.SpecificName, this));
                    _columns.Add(Constants.RoutineType, new ColumnDefinition(Constants.RoutineType, this));
                    _columns.Add(Constants.DataType, new ColumnDefinition(Constants.DataType, this));
                }

                public ColumnDefinition SpecificCatalog => _columns[Constants.SpecificCatalog];
                public ColumnDefinition SpecificSchema => _columns[Constants.SpecificSchema];
                public ColumnDefinition SpecificName => _columns[Constants.SpecificName];
                public ColumnDefinition RoutineType => _columns[Constants.RoutineType];
                public ColumnDefinition DataType => _columns[Constants.DataType];

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
                public const string RoutineType = "routine_type";
                public const string DataType = "data_type";
            }

            public static class QueryResultsMapper
            {
                private static readonly Dictionary<string, string> columnMap = new()
                {
                    {Constants.SpecificCatalog, nameof(RoutinesDto.SpecificCatalog)},
                    {Constants.SpecificSchema, nameof(RoutinesDto.SpecificSchema)},
                    {Constants.SpecificName, nameof(RoutinesDto.SpecificName)},
                    {Constants.RoutineType, nameof(RoutinesDto.RoutineType)},
                    {Constants.DataType, nameof(RoutinesDto.DataType)}
                };

                private static Func<Type, string, PropertyInfo> GetMapperFunc()
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
                    return new CustomPropertyTypeMap(typeof(RoutinesDto), GetMapperFunc());
                }
            }
        }
    }
}