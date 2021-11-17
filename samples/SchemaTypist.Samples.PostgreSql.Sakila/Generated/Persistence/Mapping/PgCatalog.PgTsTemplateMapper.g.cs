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
		public static partial class PgTsTemplateMapper
		{
			static partial class Constants
			{
				public const string Oid = "oid";
				public const string Tmplinit = "tmplinit";
				public const string Tmpllexize = "tmpllexize";
				public const string Tmplname = "tmplname";
				public const string Tmplnamespace = "tmplnamespace";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_ts_template")
				{
					Oid = new ColumnDefinition(Constants.Oid, this);
					Tmplinit = new ColumnDefinition(Constants.Tmplinit, this);
					Tmpllexize = new ColumnDefinition(Constants.Tmpllexize, this);
					Tmplname = new ColumnDefinition(Constants.Tmplname, this);
					Tmplnamespace = new ColumnDefinition(Constants.Tmplnamespace, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Oid { get; private set; }
				public ColumnDefinition Tmplinit { get; private set; }
				public ColumnDefinition Tmpllexize { get; private set; }
				public ColumnDefinition Tmplname { get; private set; }
				public ColumnDefinition Tmplnamespace { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Oid, nameof(PgTsTemplate.Oid) },
					{Constants.Tmplinit, nameof(PgTsTemplate.Tmplinit) },
					{Constants.Tmpllexize, nameof(PgTsTemplate.Tmpllexize) },
					{Constants.Tmplname, nameof(PgTsTemplate.Tmplname) },
					{Constants.Tmplnamespace, nameof(PgTsTemplate.Tmplnamespace) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgTsTemplate), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}