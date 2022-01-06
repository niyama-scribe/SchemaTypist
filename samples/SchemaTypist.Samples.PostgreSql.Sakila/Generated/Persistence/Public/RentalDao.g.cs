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
using SchemaTypist.Generated.Domain.Public;

namespace SchemaTypist.Generated.Persistence.Public
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
			public TableDefinition() : base("public.rental")
			{
				CustomerId = new ColumnDefinition(Constants.CustomerId, this);
				InventoryId = new ColumnDefinition(Constants.InventoryId, this);
				LastUpdate = new ColumnDefinition(Constants.LastUpdate, this);
				RentalDate = new ColumnDefinition(Constants.RentalDate, this);
				RentalId = new ColumnDefinition(Constants.RentalId, this);
				ReturnDate = new ColumnDefinition(Constants.ReturnDate, this);
				StaffId = new ColumnDefinition(Constants.StaffId, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition CustomerId { get; private set; }
			public ColumnDefinition InventoryId { get; private set; }
			public ColumnDefinition LastUpdate { get; private set; }
			public ColumnDefinition RentalDate { get; private set; }
			public ColumnDefinition RentalId { get; private set; }
			public ColumnDefinition ReturnDate { get; private set; }
			public ColumnDefinition StaffId { get; private set; }

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