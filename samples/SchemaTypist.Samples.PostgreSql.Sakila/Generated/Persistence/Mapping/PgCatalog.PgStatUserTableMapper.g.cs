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
		public static partial class PgStatUserTableMapper
		{
			static partial class Constants
			{
				public const string AnalyzeCount = "analyze_count";
				public const string AutoanalyzeCount = "autoanalyze_count";
				public const string AutovacuumCount = "autovacuum_count";
				public const string IdxScan = "idx_scan";
				public const string IdxTupFetch = "idx_tup_fetch";
				public const string LastAnalyze = "last_analyze";
				public const string LastAutoanalyze = "last_autoanalyze";
				public const string LastAutovacuum = "last_autovacuum";
				public const string LastVacuum = "last_vacuum";
				public const string NDeadTup = "n_dead_tup";
				public const string NInsSinceVacuum = "n_ins_since_vacuum";
				public const string NLiveTup = "n_live_tup";
				public const string NModSinceAnalyze = "n_mod_since_analyze";
				public const string NTupDel = "n_tup_del";
				public const string NTupHotUpd = "n_tup_hot_upd";
				public const string NTupIn = "n_tup_ins";
				public const string NTupUpd = "n_tup_upd";
				public const string Relid = "relid";
				public const string Relname = "relname";
				public const string Schemaname = "schemaname";
				public const string SeqScan = "seq_scan";
				public const string SeqTupRead = "seq_tup_read";
				public const string VacuumCount = "vacuum_count";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_stat_user_tables")
				{
					AnalyzeCount = new ColumnDefinition(Constants.AnalyzeCount, this);
					AutoanalyzeCount = new ColumnDefinition(Constants.AutoanalyzeCount, this);
					AutovacuumCount = new ColumnDefinition(Constants.AutovacuumCount, this);
					IdxScan = new ColumnDefinition(Constants.IdxScan, this);
					IdxTupFetch = new ColumnDefinition(Constants.IdxTupFetch, this);
					LastAnalyze = new ColumnDefinition(Constants.LastAnalyze, this);
					LastAutoanalyze = new ColumnDefinition(Constants.LastAutoanalyze, this);
					LastAutovacuum = new ColumnDefinition(Constants.LastAutovacuum, this);
					LastVacuum = new ColumnDefinition(Constants.LastVacuum, this);
					NDeadTup = new ColumnDefinition(Constants.NDeadTup, this);
					NInsSinceVacuum = new ColumnDefinition(Constants.NInsSinceVacuum, this);
					NLiveTup = new ColumnDefinition(Constants.NLiveTup, this);
					NModSinceAnalyze = new ColumnDefinition(Constants.NModSinceAnalyze, this);
					NTupDel = new ColumnDefinition(Constants.NTupDel, this);
					NTupHotUpd = new ColumnDefinition(Constants.NTupHotUpd, this);
					NTupIn = new ColumnDefinition(Constants.NTupIn, this);
					NTupUpd = new ColumnDefinition(Constants.NTupUpd, this);
					Relid = new ColumnDefinition(Constants.Relid, this);
					Relname = new ColumnDefinition(Constants.Relname, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
					SeqScan = new ColumnDefinition(Constants.SeqScan, this);
					SeqTupRead = new ColumnDefinition(Constants.SeqTupRead, this);
					VacuumCount = new ColumnDefinition(Constants.VacuumCount, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition AnalyzeCount { get; private set; }
				public ColumnDefinition AutoanalyzeCount { get; private set; }
				public ColumnDefinition AutovacuumCount { get; private set; }
				public ColumnDefinition IdxScan { get; private set; }
				public ColumnDefinition IdxTupFetch { get; private set; }
				public ColumnDefinition LastAnalyze { get; private set; }
				public ColumnDefinition LastAutoanalyze { get; private set; }
				public ColumnDefinition LastAutovacuum { get; private set; }
				public ColumnDefinition LastVacuum { get; private set; }
				public ColumnDefinition NDeadTup { get; private set; }
				public ColumnDefinition NInsSinceVacuum { get; private set; }
				public ColumnDefinition NLiveTup { get; private set; }
				public ColumnDefinition NModSinceAnalyze { get; private set; }
				public ColumnDefinition NTupDel { get; private set; }
				public ColumnDefinition NTupHotUpd { get; private set; }
				public ColumnDefinition NTupIn { get; private set; }
				public ColumnDefinition NTupUpd { get; private set; }
				public ColumnDefinition Relid { get; private set; }
				public ColumnDefinition Relname { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }
				public ColumnDefinition SeqScan { get; private set; }
				public ColumnDefinition SeqTupRead { get; private set; }
				public ColumnDefinition VacuumCount { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.AnalyzeCount, nameof(PgStatUserTable.AnalyzeCount) },
					{Constants.AutoanalyzeCount, nameof(PgStatUserTable.AutoanalyzeCount) },
					{Constants.AutovacuumCount, nameof(PgStatUserTable.AutovacuumCount) },
					{Constants.IdxScan, nameof(PgStatUserTable.IdxScan) },
					{Constants.IdxTupFetch, nameof(PgStatUserTable.IdxTupFetch) },
					{Constants.LastAnalyze, nameof(PgStatUserTable.LastAnalyze) },
					{Constants.LastAutoanalyze, nameof(PgStatUserTable.LastAutoanalyze) },
					{Constants.LastAutovacuum, nameof(PgStatUserTable.LastAutovacuum) },
					{Constants.LastVacuum, nameof(PgStatUserTable.LastVacuum) },
					{Constants.NDeadTup, nameof(PgStatUserTable.NDeadTup) },
					{Constants.NInsSinceVacuum, nameof(PgStatUserTable.NInsSinceVacuum) },
					{Constants.NLiveTup, nameof(PgStatUserTable.NLiveTup) },
					{Constants.NModSinceAnalyze, nameof(PgStatUserTable.NModSinceAnalyze) },
					{Constants.NTupDel, nameof(PgStatUserTable.NTupDel) },
					{Constants.NTupHotUpd, nameof(PgStatUserTable.NTupHotUpd) },
					{Constants.NTupIn, nameof(PgStatUserTable.NTupIn) },
					{Constants.NTupUpd, nameof(PgStatUserTable.NTupUpd) },
					{Constants.Relid, nameof(PgStatUserTable.Relid) },
					{Constants.Relname, nameof(PgStatUserTable.Relname) },
					{Constants.Schemaname, nameof(PgStatUserTable.Schemaname) },
					{Constants.SeqScan, nameof(PgStatUserTable.SeqScan) },
					{Constants.SeqTupRead, nameof(PgStatUserTable.SeqTupRead) },
					{Constants.VacuumCount, nameof(PgStatUserTable.VacuumCount) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgStatUserTable), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}