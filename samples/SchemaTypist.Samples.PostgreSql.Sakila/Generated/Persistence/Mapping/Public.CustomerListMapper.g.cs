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
	static partial class Public
	{
		public static partial class CustomerListMapper
		{
			static partial class Constants
			{
				public const string Address = "address";
				public const string City = "city";
				public const string Country = "country";
				public const string Id = "id";
				public const string Name = "name";
				public const string Note = "notes";
				public const string Phone = "phone";
				public const string Sid = "sid";
				public const string ZipCode = "zip code";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("public.customer_list")
				{
					Address = new ColumnDefinition(Constants.Address, this);
					City = new ColumnDefinition(Constants.City, this);
					Country = new ColumnDefinition(Constants.Country, this);
					Id = new ColumnDefinition(Constants.Id, this);
					Name = new ColumnDefinition(Constants.Name, this);
					Note = new ColumnDefinition(Constants.Note, this);
					Phone = new ColumnDefinition(Constants.Phone, this);
					Sid = new ColumnDefinition(Constants.Sid, this);
					ZipCode = new ColumnDefinition(Constants.ZipCode, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Address { get; private set; }
				public ColumnDefinition City { get; private set; }
				public ColumnDefinition Country { get; private set; }
				public ColumnDefinition Id { get; private set; }
				public ColumnDefinition Name { get; private set; }
				public ColumnDefinition Note { get; private set; }
				public ColumnDefinition Phone { get; private set; }
				public ColumnDefinition Sid { get; private set; }
				public ColumnDefinition ZipCode { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Address, nameof(CustomerList.Address) },
					{Constants.City, nameof(CustomerList.City) },
					{Constants.Country, nameof(CustomerList.Country) },
					{Constants.Id, nameof(CustomerList.Id) },
					{Constants.Name, nameof(CustomerList.Name) },
					{Constants.Note, nameof(CustomerList.Note) },
					{Constants.Phone, nameof(CustomerList.Phone) },
					{Constants.Sid, nameof(CustomerList.Sid) },
					{Constants.ZipCode, nameof(CustomerList.ZipCode) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(CustomerList), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}