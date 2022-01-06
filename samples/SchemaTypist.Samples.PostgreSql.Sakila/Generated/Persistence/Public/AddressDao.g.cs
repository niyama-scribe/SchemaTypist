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
	public static partial class AddressDao
	{
		static partial class Constants
		{
			public const string Address0 = "address";
			public const string Address2 = "address2";
			public const string AddressId = "address_id";
			public const string CityId = "city_id";
			public const string District = "district";
			public const string LastUpdate = "last_update";
			public const string Phone = "phone";
			public const string PostalCode = "postal_code";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			public TableDefinition() : base("public.address")
			{
				Address0 = new ColumnDefinition(Constants.Address0, this);
				Address2 = new ColumnDefinition(Constants.Address2, this);
				AddressId = new ColumnDefinition(Constants.AddressId, this);
				CityId = new ColumnDefinition(Constants.CityId, this);
				District = new ColumnDefinition(Constants.District, this);
				LastUpdate = new ColumnDefinition(Constants.LastUpdate, this);
				Phone = new ColumnDefinition(Constants.Phone, this);
				PostalCode = new ColumnDefinition(Constants.PostalCode, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition Address0 { get; private set; }
			public ColumnDefinition Address2 { get; private set; }
			public ColumnDefinition AddressId { get; private set; }
			public ColumnDefinition CityId { get; private set; }
			public ColumnDefinition District { get; private set; }
			public ColumnDefinition LastUpdate { get; private set; }
			public ColumnDefinition Phone { get; private set; }
			public ColumnDefinition PostalCode { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.Address0, nameof(Address.Address0) },
				{Constants.Address2, nameof(Address.Address2) },
				{Constants.AddressId, nameof(Address.AddressId) },
				{Constants.CityId, nameof(Address.CityId) },
				{Constants.District, nameof(Address.District) },
				{Constants.LastUpdate, nameof(Address.LastUpdate) },
				{Constants.Phone, nameof(Address.Phone) },
				{Constants.PostalCode, nameof(Address.PostalCode) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Address), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}