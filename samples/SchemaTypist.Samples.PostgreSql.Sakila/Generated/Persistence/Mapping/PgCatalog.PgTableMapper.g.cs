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
		public static partial class PgTableMapper
		{
			static partial class Constants
			{
				public const string Hasindex = "hasindexes";
				public const string Hasrule = "hasrules";
				public const string Hastrigger = "hastriggers";
				public const string Rowsecurity = "rowsecurity";
				public const string Schemaname = "schemaname";
				public const string Tablename = "tablename";
				public const string Tableowner = "tableowner";
				public const string Tablespace = "tablespace";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_tables")
				{
					Hasindex = new ColumnDefinition(Constants.Hasindex, this);
					Hasrule = new ColumnDefinition(Constants.Hasrule, this);
					Hastrigger = new ColumnDefinition(Constants.Hastrigger, this);
					Rowsecurity = new ColumnDefinition(Constants.Rowsecurity, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
					Tablename = new ColumnDefinition(Constants.Tablename, this);
					Tableowner = new ColumnDefinition(Constants.Tableowner, this);
					Tablespace = new ColumnDefinition(Constants.Tablespace, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Hasindex { get; private set; }
				public ColumnDefinition Hasrule { get; private set; }
				public ColumnDefinition Hastrigger { get; private set; }
				public ColumnDefinition Rowsecurity { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }
				public ColumnDefinition Tablename { get; private set; }
				public ColumnDefinition Tableowner { get; private set; }
				public ColumnDefinition Tablespace { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Hasindex, nameof(PgTable.Hasindex) },
					{Constants.Hasrule, nameof(PgTable.Hasrule) },
					{Constants.Hastrigger, nameof(PgTable.Hastrigger) },
					{Constants.Rowsecurity, nameof(PgTable.Rowsecurity) },
					{Constants.Schemaname, nameof(PgTable.Schemaname) },
					{Constants.Tablename, nameof(PgTable.Tablename) },
					{Constants.Tableowner, nameof(PgTable.Tableowner) },
					{Constants.Tablespace, nameof(PgTable.Tablespace) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgTable), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}