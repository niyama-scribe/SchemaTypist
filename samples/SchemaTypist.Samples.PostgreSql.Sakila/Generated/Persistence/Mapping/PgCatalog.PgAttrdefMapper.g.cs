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
		public static partial class PgAttrdefMapper
		{
			static partial class Constants
			{
				public const string Adbin = "adbin";
				public const string Adnum = "adnum";
				public const string Adrelid = "adrelid";
				public const string Oid = "oid";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_attrdef")
				{
					Adbin = new ColumnDefinition(Constants.Adbin, this);
					Adnum = new ColumnDefinition(Constants.Adnum, this);
					Adrelid = new ColumnDefinition(Constants.Adrelid, this);
					Oid = new ColumnDefinition(Constants.Oid, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Adbin { get; private set; }
				public ColumnDefinition Adnum { get; private set; }
				public ColumnDefinition Adrelid { get; private set; }
				public ColumnDefinition Oid { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Adbin, nameof(PgAttrdef.Adbin) },
					{Constants.Adnum, nameof(PgAttrdef.Adnum) },
					{Constants.Adrelid, nameof(PgAttrdef.Adrelid) },
					{Constants.Oid, nameof(PgAttrdef.Oid) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgAttrdef), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}