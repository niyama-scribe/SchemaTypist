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
	public static partial class RentalDao
	{
		static partial class Constants
		{
			public const string CustomerId = "customer_id";
			public const string InventoryId = "inventory_id";
			public const string LastUpdate = "last_update";
			public const string RentalDate = "rental_date";
			public const string RentalId = "rental_id";
			public const string ReturnDate = "return_date";
			public const string StaffId = "staff_id";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("public.rental")
			{
				_columns.Add(Constants.CustomerId, new ColumnDefinition(Constants.CustomerId, this));
				_columns.Add(Constants.InventoryId, new ColumnDefinition(Constants.InventoryId, this));
				_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
				_columns.Add(Constants.RentalDate, new ColumnDefinition(Constants.RentalDate, this));
				_columns.Add(Constants.RentalId, new ColumnDefinition(Constants.RentalId, this));
				_columns.Add(Constants.ReturnDate, new ColumnDefinition(Constants.ReturnDate, this));
				_columns.Add(Constants.StaffId, new ColumnDefinition(Constants.StaffId, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition CustomerId => _columns[Constants.CustomerId];
			public ColumnDefinition InventoryId => _columns[Constants.InventoryId];
			public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];
			public ColumnDefinition RentalDate => _columns[Constants.RentalDate];
			public ColumnDefinition RentalId => _columns[Constants.RentalId];
			public ColumnDefinition ReturnDate => _columns[Constants.ReturnDate];
			public ColumnDefinition StaffId => _columns[Constants.StaffId];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.CustomerId, nameof(Rental.CustomerId) },
				{Constants.InventoryId, nameof(Rental.InventoryId) },
				{Constants.LastUpdate, nameof(Rental.LastUpdate) },
				{Constants.RentalDate, nameof(Rental.RentalDate) },
				{Constants.RentalId, nameof(Rental.RentalId) },
				{Constants.ReturnDate, nameof(Rental.ReturnDate) },
				{Constants.StaffId, nameof(Rental.StaffId) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Rental), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}