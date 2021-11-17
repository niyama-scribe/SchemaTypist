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
		public static partial class PgStatisticMapper
		{
			static partial class Constants
			{
				public const string Staattnum = "staattnum";
				public const string Stacoll1 = "stacoll1";
				public const string Stacoll2 = "stacoll2";
				public const string Stacoll3 = "stacoll3";
				public const string Stacoll4 = "stacoll4";
				public const string Stacoll5 = "stacoll5";
				public const string Stadistinct = "stadistinct";
				public const string Stainherit = "stainherit";
				public const string Stakind1 = "stakind1";
				public const string Stakind2 = "stakind2";
				public const string Stakind3 = "stakind3";
				public const string Stakind4 = "stakind4";
				public const string Stakind5 = "stakind5";
				public const string Stanullfrac = "stanullfrac";
				public const string Stanumbers1 = "stanumbers1";
				public const string Stanumbers2 = "stanumbers2";
				public const string Stanumbers3 = "stanumbers3";
				public const string Stanumbers4 = "stanumbers4";
				public const string Stanumbers5 = "stanumbers5";
				public const string Staop1 = "staop1";
				public const string Staop2 = "staop2";
				public const string Staop3 = "staop3";
				public const string Staop4 = "staop4";
				public const string Staop5 = "staop5";
				public const string Starelid = "starelid";
				public const string Stavalues1 = "stavalues1";
				public const string Stavalues2 = "stavalues2";
				public const string Stavalues3 = "stavalues3";
				public const string Stavalues4 = "stavalues4";
				public const string Stavalues5 = "stavalues5";
				public const string Stawidth = "stawidth";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_statistic")
				{
					Staattnum = new ColumnDefinition(Constants.Staattnum, this);
					Stacoll1 = new ColumnDefinition(Constants.Stacoll1, this);
					Stacoll2 = new ColumnDefinition(Constants.Stacoll2, this);
					Stacoll3 = new ColumnDefinition(Constants.Stacoll3, this);
					Stacoll4 = new ColumnDefinition(Constants.Stacoll4, this);
					Stacoll5 = new ColumnDefinition(Constants.Stacoll5, this);
					Stadistinct = new ColumnDefinition(Constants.Stadistinct, this);
					Stainherit = new ColumnDefinition(Constants.Stainherit, this);
					Stakind1 = new ColumnDefinition(Constants.Stakind1, this);
					Stakind2 = new ColumnDefinition(Constants.Stakind2, this);
					Stakind3 = new ColumnDefinition(Constants.Stakind3, this);
					Stakind4 = new ColumnDefinition(Constants.Stakind4, this);
					Stakind5 = new ColumnDefinition(Constants.Stakind5, this);
					Stanullfrac = new ColumnDefinition(Constants.Stanullfrac, this);
					Stanumbers1 = new ColumnDefinition(Constants.Stanumbers1, this);
					Stanumbers2 = new ColumnDefinition(Constants.Stanumbers2, this);
					Stanumbers3 = new ColumnDefinition(Constants.Stanumbers3, this);
					Stanumbers4 = new ColumnDefinition(Constants.Stanumbers4, this);
					Stanumbers5 = new ColumnDefinition(Constants.Stanumbers5, this);
					Staop1 = new ColumnDefinition(Constants.Staop1, this);
					Staop2 = new ColumnDefinition(Constants.Staop2, this);
					Staop3 = new ColumnDefinition(Constants.Staop3, this);
					Staop4 = new ColumnDefinition(Constants.Staop4, this);
					Staop5 = new ColumnDefinition(Constants.Staop5, this);
					Starelid = new ColumnDefinition(Constants.Starelid, this);
					Stavalues1 = new ColumnDefinition(Constants.Stavalues1, this);
					Stavalues2 = new ColumnDefinition(Constants.Stavalues2, this);
					Stavalues3 = new ColumnDefinition(Constants.Stavalues3, this);
					Stavalues4 = new ColumnDefinition(Constants.Stavalues4, this);
					Stavalues5 = new ColumnDefinition(Constants.Stavalues5, this);
					Stawidth = new ColumnDefinition(Constants.Stawidth, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Staattnum { get; private set; }
				public ColumnDefinition Stacoll1 { get; private set; }
				public ColumnDefinition Stacoll2 { get; private set; }
				public ColumnDefinition Stacoll3 { get; private set; }
				public ColumnDefinition Stacoll4 { get; private set; }
				public ColumnDefinition Stacoll5 { get; private set; }
				public ColumnDefinition Stadistinct { get; private set; }
				public ColumnDefinition Stainherit { get; private set; }
				public ColumnDefinition Stakind1 { get; private set; }
				public ColumnDefinition Stakind2 { get; private set; }
				public ColumnDefinition Stakind3 { get; private set; }
				public ColumnDefinition Stakind4 { get; private set; }
				public ColumnDefinition Stakind5 { get; private set; }
				public ColumnDefinition Stanullfrac { get; private set; }
				public ColumnDefinition Stanumbers1 { get; private set; }
				public ColumnDefinition Stanumbers2 { get; private set; }
				public ColumnDefinition Stanumbers3 { get; private set; }
				public ColumnDefinition Stanumbers4 { get; private set; }
				public ColumnDefinition Stanumbers5 { get; private set; }
				public ColumnDefinition Staop1 { get; private set; }
				public ColumnDefinition Staop2 { get; private set; }
				public ColumnDefinition Staop3 { get; private set; }
				public ColumnDefinition Staop4 { get; private set; }
				public ColumnDefinition Staop5 { get; private set; }
				public ColumnDefinition Starelid { get; private set; }
				public ColumnDefinition Stavalues1 { get; private set; }
				public ColumnDefinition Stavalues2 { get; private set; }
				public ColumnDefinition Stavalues3 { get; private set; }
				public ColumnDefinition Stavalues4 { get; private set; }
				public ColumnDefinition Stavalues5 { get; private set; }
				public ColumnDefinition Stawidth { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Staattnum, nameof(PgStatistic.Staattnum) },
					{Constants.Stacoll1, nameof(PgStatistic.Stacoll1) },
					{Constants.Stacoll2, nameof(PgStatistic.Stacoll2) },
					{Constants.Stacoll3, nameof(PgStatistic.Stacoll3) },
					{Constants.Stacoll4, nameof(PgStatistic.Stacoll4) },
					{Constants.Stacoll5, nameof(PgStatistic.Stacoll5) },
					{Constants.Stadistinct, nameof(PgStatistic.Stadistinct) },
					{Constants.Stainherit, nameof(PgStatistic.Stainherit) },
					{Constants.Stakind1, nameof(PgStatistic.Stakind1) },
					{Constants.Stakind2, nameof(PgStatistic.Stakind2) },
					{Constants.Stakind3, nameof(PgStatistic.Stakind3) },
					{Constants.Stakind4, nameof(PgStatistic.Stakind4) },
					{Constants.Stakind5, nameof(PgStatistic.Stakind5) },
					{Constants.Stanullfrac, nameof(PgStatistic.Stanullfrac) },
					{Constants.Stanumbers1, nameof(PgStatistic.Stanumbers1) },
					{Constants.Stanumbers2, nameof(PgStatistic.Stanumbers2) },
					{Constants.Stanumbers3, nameof(PgStatistic.Stanumbers3) },
					{Constants.Stanumbers4, nameof(PgStatistic.Stanumbers4) },
					{Constants.Stanumbers5, nameof(PgStatistic.Stanumbers5) },
					{Constants.Staop1, nameof(PgStatistic.Staop1) },
					{Constants.Staop2, nameof(PgStatistic.Staop2) },
					{Constants.Staop3, nameof(PgStatistic.Staop3) },
					{Constants.Staop4, nameof(PgStatistic.Staop4) },
					{Constants.Staop5, nameof(PgStatistic.Staop5) },
					{Constants.Starelid, nameof(PgStatistic.Starelid) },
					{Constants.Stavalues1, nameof(PgStatistic.Stavalues1) },
					{Constants.Stavalues2, nameof(PgStatistic.Stavalues2) },
					{Constants.Stavalues3, nameof(PgStatistic.Stavalues3) },
					{Constants.Stavalues4, nameof(PgStatistic.Stavalues4) },
					{Constants.Stavalues5, nameof(PgStatistic.Stavalues5) },
					{Constants.Stawidth, nameof(PgStatistic.Stawidth) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgStatistic), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}