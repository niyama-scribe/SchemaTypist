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
		public static partial class PgPolicyMapper
		{
			static partial class Constants
			{
				public const string Oid = "oid";
				public const string Polcmd = "polcmd";
				public const string Polname = "polname";
				public const string Polpermissive = "polpermissive";
				public const string Polqual = "polqual";
				public const string Polrelid = "polrelid";
				public const string Polrole = "polroles";
				public const string Polwithcheck = "polwithcheck";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_policy")
				{
					Oid = new ColumnDefinition(Constants.Oid, this);
					Polcmd = new ColumnDefinition(Constants.Polcmd, this);
					Polname = new ColumnDefinition(Constants.Polname, this);
					Polpermissive = new ColumnDefinition(Constants.Polpermissive, this);
					Polqual = new ColumnDefinition(Constants.Polqual, this);
					Polrelid = new ColumnDefinition(Constants.Polrelid, this);
					Polrole = new ColumnDefinition(Constants.Polrole, this);
					Polwithcheck = new ColumnDefinition(Constants.Polwithcheck, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Oid { get; private set; }
				public ColumnDefinition Polcmd { get; private set; }
				public ColumnDefinition Polname { get; private set; }
				public ColumnDefinition Polpermissive { get; private set; }
				public ColumnDefinition Polqual { get; private set; }
				public ColumnDefinition Polrelid { get; private set; }
				public ColumnDefinition Polrole { get; private set; }
				public ColumnDefinition Polwithcheck { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Oid, nameof(PgPolicy.Oid) },
					{Constants.Polcmd, nameof(PgPolicy.Polcmd) },
					{Constants.Polname, nameof(PgPolicy.Polname) },
					{Constants.Polpermissive, nameof(PgPolicy.Polpermissive) },
					{Constants.Polqual, nameof(PgPolicy.Polqual) },
					{Constants.Polrelid, nameof(PgPolicy.Polrelid) },
					{Constants.Polrole, nameof(PgPolicy.Polrole) },
					{Constants.Polwithcheck, nameof(PgPolicy.Polwithcheck) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgPolicy), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}