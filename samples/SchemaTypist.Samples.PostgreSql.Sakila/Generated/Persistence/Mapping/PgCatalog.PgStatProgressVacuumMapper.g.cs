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
		public static partial class PgStatProgressVacuumMapper
		{
			static partial class Constants
			{
				public const string Datid = "datid";
				public const string Datname = "datname";
				public const string HeapBlksScanned = "heap_blks_scanned";
				public const string HeapBlksTotal = "heap_blks_total";
				public const string HeapBlksVacuumed = "heap_blks_vacuumed";
				public const string IndexVacuumCount = "index_vacuum_count";
				public const string MaxDeadTuple = "max_dead_tuples";
				public const string NumDeadTuple = "num_dead_tuples";
				public const string Phase = "phase";
				public const string Pid = "pid";
				public const string Relid = "relid";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_stat_progress_vacuum")
				{
					Datid = new ColumnDefinition(Constants.Datid, this);
					Datname = new ColumnDefinition(Constants.Datname, this);
					HeapBlksScanned = new ColumnDefinition(Constants.HeapBlksScanned, this);
					HeapBlksTotal = new ColumnDefinition(Constants.HeapBlksTotal, this);
					HeapBlksVacuumed = new ColumnDefinition(Constants.HeapBlksVacuumed, this);
					IndexVacuumCount = new ColumnDefinition(Constants.IndexVacuumCount, this);
					MaxDeadTuple = new ColumnDefinition(Constants.MaxDeadTuple, this);
					NumDeadTuple = new ColumnDefinition(Constants.NumDeadTuple, this);
					Phase = new ColumnDefinition(Constants.Phase, this);
					Pid = new ColumnDefinition(Constants.Pid, this);
					Relid = new ColumnDefinition(Constants.Relid, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Datid { get; private set; }
				public ColumnDefinition Datname { get; private set; }
				public ColumnDefinition HeapBlksScanned { get; private set; }
				public ColumnDefinition HeapBlksTotal { get; private set; }
				public ColumnDefinition HeapBlksVacuumed { get; private set; }
				public ColumnDefinition IndexVacuumCount { get; private set; }
				public ColumnDefinition MaxDeadTuple { get; private set; }
				public ColumnDefinition NumDeadTuple { get; private set; }
				public ColumnDefinition Phase { get; private set; }
				public ColumnDefinition Pid { get; private set; }
				public ColumnDefinition Relid { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Datid, nameof(PgStatProgressVacuum.Datid) },
					{Constants.Datname, nameof(PgStatProgressVacuum.Datname) },
					{Constants.HeapBlksScanned, nameof(PgStatProgressVacuum.HeapBlksScanned) },
					{Constants.HeapBlksTotal, nameof(PgStatProgressVacuum.HeapBlksTotal) },
					{Constants.HeapBlksVacuumed, nameof(PgStatProgressVacuum.HeapBlksVacuumed) },
					{Constants.IndexVacuumCount, nameof(PgStatProgressVacuum.IndexVacuumCount) },
					{Constants.MaxDeadTuple, nameof(PgStatProgressVacuum.MaxDeadTuple) },
					{Constants.NumDeadTuple, nameof(PgStatProgressVacuum.NumDeadTuple) },
					{Constants.Phase, nameof(PgStatProgressVacuum.Phase) },
					{Constants.Pid, nameof(PgStatProgressVacuum.Pid) },
					{Constants.Relid, nameof(PgStatProgressVacuum.Relid) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgStatProgressVacuum), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}