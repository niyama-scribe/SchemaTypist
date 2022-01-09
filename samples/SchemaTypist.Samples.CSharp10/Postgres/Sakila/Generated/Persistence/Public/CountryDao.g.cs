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
using SchemaTypistSamples.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypistSamples.Postgres.Sakila.Generated.Persistence.Public
{
	public static partial class CountryDao
	{
		static partial class Constants
		{
			public const string Country0 = "country";
			public const string CountryId = "country_id";
			public const string LastUpdate = "last_update";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			public TableDefinition() : base("public.country")
			{
				Country0 = new ColumnDefinition(Constants.Country0, this);
				CountryId = new ColumnDefinition(Constants.CountryId, this);
				LastUpdate = new ColumnDefinition(Constants.LastUpdate, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition Country0 { get; private set; }
			public ColumnDefinition CountryId { get; private set; }
			public ColumnDefinition LastUpdate { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.Country0, nameof(Country.Country0) },
				{Constants.CountryId, nameof(Country.CountryId) },
				{Constants.LastUpdate, nameof(Country.LastUpdate) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Country), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}