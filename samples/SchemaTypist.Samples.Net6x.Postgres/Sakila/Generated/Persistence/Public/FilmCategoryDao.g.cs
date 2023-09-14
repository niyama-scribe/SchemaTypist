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

public static partial class FilmCategoryDao
{
	static partial class Constants
	{
		public const string CategoryId = "category_id";
		public const string FilmId = "film_id";
		public const string LastUpdate = "last_update";
	}

	public static TableDefinition Table => new TableDefinition();

	public partial class TableDefinition : TabularDefinition
	{
		private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
            
		public TableDefinition() : base("public.film_category")
		{
			_columns.Add(Constants.CategoryId, new ColumnDefinition(Constants.CategoryId, this));
			_columns.Add(Constants.FilmId, new ColumnDefinition(Constants.FilmId, this));
			_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
		}

		public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

		public ColumnDefinition CategoryId => _columns[Constants.CategoryId];
		public ColumnDefinition FilmId => _columns[Constants.FilmId];
		public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];

		public IEnumerable<ColumnDefinition> Star => _columns.Values;
	}

	public static partial class QueryResults
	{
		private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
		{
			{Constants.CategoryId, nameof(FilmCategory.CategoryId) },
			{Constants.FilmId, nameof(FilmCategory.FilmId) },
			{Constants.LastUpdate, nameof(FilmCategory.LastUpdate) },
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
			var typeMap = new CustomPropertyTypeMap(typeof(FilmCategory), GetMapperFunc());
			CustomizeTypeMap(typeMap);
			return typeMap;
		}

		static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
	}
}