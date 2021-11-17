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
		public static partial class PgStatioAllTableMapper
		{
			static partial class Constants
			{
				public const string HeapBlksHit = "heap_blks_hit";
				public const string HeapBlksRead = "heap_blks_read";
				public const string IdxBlksHit = "idx_blks_hit";
				public const string IdxBlksRead = "idx_blks_read";
				public const string Relid = "relid";
				public const string Relname = "relname";
				public const string Schemaname = "schemaname";
				public const string TidxBlksHit = "tidx_blks_hit";
				public const string TidxBlksRead = "tidx_blks_read";
				public const string ToastBlksHit = "toast_blks_hit";
				public const string ToastBlksRead = "toast_blks_read";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_statio_all_tables")
				{
					HeapBlksHit = new ColumnDefinition(Constants.HeapBlksHit, this);
					HeapBlksRead = new ColumnDefinition(Constants.HeapBlksRead, this);
					IdxBlksHit = new ColumnDefinition(Constants.IdxBlksHit, this);
					IdxBlksRead = new ColumnDefinition(Constants.IdxBlksRead, this);
					Relid = new ColumnDefinition(Constants.Relid, this);
					Relname = new ColumnDefinition(Constants.Relname, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
					TidxBlksHit = new ColumnDefinition(Constants.TidxBlksHit, this);
					TidxBlksRead = new ColumnDefinition(Constants.TidxBlksRead, this);
					ToastBlksHit = new ColumnDefinition(Constants.ToastBlksHit, this);
					ToastBlksRead = new ColumnDefinition(Constants.ToastBlksRead, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition HeapBlksHit { get; private set; }
				public ColumnDefinition HeapBlksRead { get; private set; }
				public ColumnDefinition IdxBlksHit { get; private set; }
				public ColumnDefinition IdxBlksRead { get; private set; }
				public ColumnDefinition Relid { get; private set; }
				public ColumnDefinition Relname { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }
				public ColumnDefinition TidxBlksHit { get; private set; }
				public ColumnDefinition TidxBlksRead { get; private set; }
				public ColumnDefinition ToastBlksHit { get; private set; }
				public ColumnDefinition ToastBlksRead { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.HeapBlksHit, nameof(PgStatioAllTable.HeapBlksHit) },
					{Constants.HeapBlksRead, nameof(PgStatioAllTable.HeapBlksRead) },
					{Constants.IdxBlksHit, nameof(PgStatioAllTable.IdxBlksHit) },
					{Constants.IdxBlksRead, nameof(PgStatioAllTable.IdxBlksRead) },
					{Constants.Relid, nameof(PgStatioAllTable.Relid) },
					{Constants.Relname, nameof(PgStatioAllTable.Relname) },
					{Constants.Schemaname, nameof(PgStatioAllTable.Schemaname) },
					{Constants.TidxBlksHit, nameof(PgStatioAllTable.TidxBlksHit) },
					{Constants.TidxBlksRead, nameof(PgStatioAllTable.TidxBlksRead) },
					{Constants.ToastBlksHit, nameof(PgStatioAllTable.ToastBlksHit) },
					{Constants.ToastBlksRead, nameof(PgStatioAllTable.ToastBlksRead) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgStatioAllTable), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}