//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SchemaTypist.
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
using SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypist.Samples.Net6x.Postgres.Sakila.Generated.Persistence.Public;

public static partial class CityDao
{
	static partial class Constants
	{
		public const string City0 = "city";
		public const string CityId = "city_id";
		public const string CountryId = "country_id";
		public const string LastUpdate = "last_update";
	}

	public static TableDefinition Table => new TableDefinition();

	public partial class TableDefinition : TabularDefinition
	{
		private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
            
		public TableDefinition() : base("public.city")
		{
			_columns.Add(Constants.City0, new ColumnDefinition(Constants.City0, this));
			_columns.Add(Constants.CityId, new ColumnDefinition(Constants.CityId, this));
			_columns.Add(Constants.CountryId, new ColumnDefinition(Constants.CountryId, this));
			_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
		}

		public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

		public ColumnDefinition City0 => _columns[Constants.City0];
		public ColumnDefinition CityId => _columns[Constants.CityId];
		public ColumnDefinition CountryId => _columns[Constants.CountryId];
		public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];

		public IEnumerable<ColumnDefinition> Star => _columns.Values;
	}

	public static partial class QueryResults
	{
		private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
		{
			{Constants.City0, nameof(City.City0) },
			{Constants.CityId, nameof(City.CityId) },
			{Constants.CountryId, nameof(City.CountryId) },
			{Constants.LastUpdate, nameof(City.LastUpdate) },
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
			var typeMap = new CustomPropertyTypeMap(typeof(City), GetMapperFunc());
			CustomizeTypeMap(typeMap);
			return typeMap;
		}

		static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
	}
}