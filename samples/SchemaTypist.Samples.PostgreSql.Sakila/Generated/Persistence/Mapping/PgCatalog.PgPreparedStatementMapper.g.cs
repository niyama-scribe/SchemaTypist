﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dapper;
using SchemaTypist;
using SchemaTypist.DatabaseMetadata;
using System;
using System.Collections.Generic;
using System.Reflection;
using SchemaTypist.Generated.Domain;

namespace SchemaTypist.Generated.Persistence.Mapping
{
	static partial class PgCatalog
	{
		public static partial class PgPreparedStatementMapper
		{
			static partial class Constants
			{
				public const string CustomPlan = "custom_plans";
				public const string FromSql = "from_sql";
				public const string GenericPlan = "generic_plans";
				public const string Name = "name";
				public const string ParameterType = "parameter_types";
				public const string PrepareTime = "prepare_time";
				public const string Statement = "statement";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_prepared_statements")
				{
					CustomPlan = new ColumnDefinition(Constants.CustomPlan, this);
					FromSql = new ColumnDefinition(Constants.FromSql, this);
					GenericPlan = new ColumnDefinition(Constants.GenericPlan, this);
					Name = new ColumnDefinition(Constants.Name, this);
					ParameterType = new ColumnDefinition(Constants.ParameterType, this);
					PrepareTime = new ColumnDefinition(Constants.PrepareTime, this);
					Statement = new ColumnDefinition(Constants.Statement, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition CustomPlan { get; private set; }
				public ColumnDefinition FromSql { get; private set; }
				public ColumnDefinition GenericPlan { get; private set; }
				public ColumnDefinition Name { get; private set; }
				public ColumnDefinition ParameterType { get; private set; }
				public ColumnDefinition PrepareTime { get; private set; }
				public ColumnDefinition Statement { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.CustomPlan, nameof(PgPreparedStatement.CustomPlan) },
					{Constants.FromSql, nameof(PgPreparedStatement.FromSql) },
					{Constants.GenericPlan, nameof(PgPreparedStatement.GenericPlan) },
					{Constants.Name, nameof(PgPreparedStatement.Name) },
					{Constants.ParameterType, nameof(PgPreparedStatement.ParameterType) },
					{Constants.PrepareTime, nameof(PgPreparedStatement.PrepareTime) },
					{Constants.Statement, nameof(PgPreparedStatement.Statement) },
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

				public static CustomPropertyTypeMap GetTypeMap()
				{
					var typeMap = new CustomPropertyTypeMap(typeof(PgPreparedStatement), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}