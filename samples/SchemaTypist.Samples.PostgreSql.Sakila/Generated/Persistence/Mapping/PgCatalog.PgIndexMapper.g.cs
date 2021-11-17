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
		public static partial class PgIndexMapper
		{
			static partial class Constants
			{
				public const string Indexdef = "indexdef";
				public const string Indexname = "indexname";
				public const string Schemaname = "schemaname";
				public const string Tablename = "tablename";
				public const string Tablespace = "tablespace";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_indexes")
				{
					Indexdef = new ColumnDefinition(Constants.Indexdef, this);
					Indexname = new ColumnDefinition(Constants.Indexname, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
					Tablename = new ColumnDefinition(Constants.Tablename, this);
					Tablespace = new ColumnDefinition(Constants.Tablespace, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Indexdef { get; private set; }
				public ColumnDefinition Indexname { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }
				public ColumnDefinition Tablename { get; private set; }
				public ColumnDefinition Tablespace { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Indexdef, nameof(PgIndex.Indexdef) },
					{Constants.Indexname, nameof(PgIndex.Indexname) },
					{Constants.Schemaname, nameof(PgIndex.Schemaname) },
					{Constants.Tablename, nameof(PgIndex.Tablename) },
					{Constants.Tablespace, nameof(PgIndex.Tablespace) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgIndex), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}