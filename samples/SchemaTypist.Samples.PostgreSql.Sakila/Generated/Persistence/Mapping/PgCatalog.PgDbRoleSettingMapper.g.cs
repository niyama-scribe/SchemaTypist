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
		public static partial class PgDbRoleSettingMapper
		{
			static partial class Constants
			{
				public const string Setconfig = "setconfig";
				public const string Setdatabase = "setdatabase";
				public const string Setrole = "setrole";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_db_role_setting")
				{
					Setconfig = new ColumnDefinition(Constants.Setconfig, this);
					Setdatabase = new ColumnDefinition(Constants.Setdatabase, this);
					Setrole = new ColumnDefinition(Constants.Setrole, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Setconfig { get; private set; }
				public ColumnDefinition Setdatabase { get; private set; }
				public ColumnDefinition Setrole { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Setconfig, nameof(PgDbRoleSetting.Setconfig) },
					{Constants.Setdatabase, nameof(PgDbRoleSetting.Setdatabase) },
					{Constants.Setrole, nameof(PgDbRoleSetting.Setrole) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgDbRoleSetting), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}