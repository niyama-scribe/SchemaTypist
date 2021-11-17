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
		public static partial class PgStatioSysIndexMapper
		{
			static partial class Constants
			{
				public const string IdxBlksHit = "idx_blks_hit";
				public const string IdxBlksRead = "idx_blks_read";
				public const string Indexrelid = "indexrelid";
				public const string Indexrelname = "indexrelname";
				public const string Relid = "relid";
				public const string Relname = "relname";
				public const string Schemaname = "schemaname";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_statio_sys_indexes")
				{
					IdxBlksHit = new ColumnDefinition(Constants.IdxBlksHit, this);
					IdxBlksRead = new ColumnDefinition(Constants.IdxBlksRead, this);
					Indexrelid = new ColumnDefinition(Constants.Indexrelid, this);
					Indexrelname = new ColumnDefinition(Constants.Indexrelname, this);
					Relid = new ColumnDefinition(Constants.Relid, this);
					Relname = new ColumnDefinition(Constants.Relname, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition IdxBlksHit { get; private set; }
				public ColumnDefinition IdxBlksRead { get; private set; }
				public ColumnDefinition Indexrelid { get; private set; }
				public ColumnDefinition Indexrelname { get; private set; }
				public ColumnDefinition Relid { get; private set; }
				public ColumnDefinition Relname { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.IdxBlksHit, nameof(PgStatioSysIndex.IdxBlksHit) },
					{Constants.IdxBlksRead, nameof(PgStatioSysIndex.IdxBlksRead) },
					{Constants.Indexrelid, nameof(PgStatioSysIndex.Indexrelid) },
					{Constants.Indexrelname, nameof(PgStatioSysIndex.Indexrelname) },
					{Constants.Relid, nameof(PgStatioSysIndex.Relid) },
					{Constants.Relname, nameof(PgStatioSysIndex.Relname) },
					{Constants.Schemaname, nameof(PgStatioSysIndex.Schemaname) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgStatioSysIndex), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}