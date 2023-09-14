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
using SchemaTypist.Samples.NetStandard20.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypist.Samples.NetStandard20.Postgres.Sakila.Generated.Persistence.Public
{
	public static partial class InventoryDao
	{
		static partial class Constants
		{
			public const string FilmId = "film_id";
			public const string InventoryId = "inventory_id";
			public const string LastUpdate = "last_update";
			public const string StoreId = "store_id";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("public.inventory")
			{
				_columns.Add(Constants.FilmId, new ColumnDefinition(Constants.FilmId, this));
				_columns.Add(Constants.InventoryId, new ColumnDefinition(Constants.InventoryId, this));
				_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
				_columns.Add(Constants.StoreId, new ColumnDefinition(Constants.StoreId, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition FilmId => _columns[Constants.FilmId];
			public ColumnDefinition InventoryId => _columns[Constants.InventoryId];
			public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];
			public ColumnDefinition StoreId => _columns[Constants.StoreId];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.FilmId, nameof(Inventory.FilmId) },
				{Constants.InventoryId, nameof(Inventory.InventoryId) },
				{Constants.LastUpdate, nameof(Inventory.LastUpdate) },
				{Constants.StoreId, nameof(Inventory.StoreId) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Inventory), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}