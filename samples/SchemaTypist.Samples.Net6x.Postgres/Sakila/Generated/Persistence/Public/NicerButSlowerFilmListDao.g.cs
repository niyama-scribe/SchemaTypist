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

public static partial class NicerButSlowerFilmListDao
{
	static partial class Constants
	{
		public const string Actor = "actors";
		public const string Category = "category";
		public const string Description = "description";
		public const string Fid = "fid";
		public const string Length = "length";
		public const string Price = "price";
		public const string Rating = "rating";
		public const string Title = "title";
	}

	public static TableDefinition Table => new TableDefinition();

	public partial class TableDefinition : TabularDefinition
	{
		private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
            
		public TableDefinition() : base("public.nicer_but_slower_film_list")
		{
			_columns.Add(Constants.Actor, new ColumnDefinition(Constants.Actor, this));
			_columns.Add(Constants.Category, new ColumnDefinition(Constants.Category, this));
			_columns.Add(Constants.Description, new ColumnDefinition(Constants.Description, this));
			_columns.Add(Constants.Fid, new ColumnDefinition(Constants.Fid, this));
			_columns.Add(Constants.Length, new ColumnDefinition(Constants.Length, this));
			_columns.Add(Constants.Price, new ColumnDefinition(Constants.Price, this));
			_columns.Add(Constants.Rating, new ColumnDefinition(Constants.Rating, this));
			_columns.Add(Constants.Title, new ColumnDefinition(Constants.Title, this));
		}

		public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

		public ColumnDefinition Actor => _columns[Constants.Actor];
		public ColumnDefinition Category => _columns[Constants.Category];
		public ColumnDefinition Description => _columns[Constants.Description];
		public ColumnDefinition Fid => _columns[Constants.Fid];
		public ColumnDefinition Length => _columns[Constants.Length];
		public ColumnDefinition Price => _columns[Constants.Price];
		public ColumnDefinition Rating => _columns[Constants.Rating];
		public ColumnDefinition Title => _columns[Constants.Title];

		public IEnumerable<ColumnDefinition> Star => _columns.Values;
	}

	public static partial class QueryResults
	{
		private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
		{
			{Constants.Actor, nameof(NicerButSlowerFilmList.Actor) },
			{Constants.Category, nameof(NicerButSlowerFilmList.Category) },
			{Constants.Description, nameof(NicerButSlowerFilmList.Description) },
			{Constants.Fid, nameof(NicerButSlowerFilmList.Fid) },
			{Constants.Length, nameof(NicerButSlowerFilmList.Length) },
			{Constants.Price, nameof(NicerButSlowerFilmList.Price) },
			{Constants.Rating, nameof(NicerButSlowerFilmList.Rating) },
			{Constants.Title, nameof(NicerButSlowerFilmList.Title) },
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
			var typeMap = new CustomPropertyTypeMap(typeof(NicerButSlowerFilmList), GetMapperFunc());
			CustomizeTypeMap(typeMap);
			return typeMap;
		}

		static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
	}
}