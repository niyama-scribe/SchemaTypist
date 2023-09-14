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

public static partial class StaffListDao
{
	static partial class Constants
	{
		public const string Address = "address";
		public const string City = "city";
		public const string Country = "country";
		public const string Id = "id";
		public const string Name = "name";
		public const string Phone = "phone";
		public const string Sid = "sid";
		public const string ZipCode = "zip code";
	}

	public static TableDefinition Table => new TableDefinition();

	public partial class TableDefinition : TabularDefinition
	{
		private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
            
		public TableDefinition() : base("public.staff_list")
		{
			_columns.Add(Constants.Address, new ColumnDefinition(Constants.Address, this));
			_columns.Add(Constants.City, new ColumnDefinition(Constants.City, this));
			_columns.Add(Constants.Country, new ColumnDefinition(Constants.Country, this));
			_columns.Add(Constants.Id, new ColumnDefinition(Constants.Id, this));
			_columns.Add(Constants.Name, new ColumnDefinition(Constants.Name, this));
			_columns.Add(Constants.Phone, new ColumnDefinition(Constants.Phone, this));
			_columns.Add(Constants.Sid, new ColumnDefinition(Constants.Sid, this));
			_columns.Add(Constants.ZipCode, new ColumnDefinition(Constants.ZipCode, this));
		}

		public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

		public ColumnDefinition Address => _columns[Constants.Address];
		public ColumnDefinition City => _columns[Constants.City];
		public ColumnDefinition Country => _columns[Constants.Country];
		public ColumnDefinition Id => _columns[Constants.Id];
		public ColumnDefinition Name => _columns[Constants.Name];
		public ColumnDefinition Phone => _columns[Constants.Phone];
		public ColumnDefinition Sid => _columns[Constants.Sid];
		public ColumnDefinition ZipCode => _columns[Constants.ZipCode];

		public IEnumerable<ColumnDefinition> Star => _columns.Values;
	}

	public static partial class QueryResults
	{
		private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
		{
			{Constants.Address, nameof(StaffList.Address) },
			{Constants.City, nameof(StaffList.City) },
			{Constants.Country, nameof(StaffList.Country) },
			{Constants.Id, nameof(StaffList.Id) },
			{Constants.Name, nameof(StaffList.Name) },
			{Constants.Phone, nameof(StaffList.Phone) },
			{Constants.Sid, nameof(StaffList.Sid) },
			{Constants.ZipCode, nameof(StaffList.ZipCode) },
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
			var typeMap = new CustomPropertyTypeMap(typeof(StaffList), GetMapperFunc());
			CustomizeTypeMap(typeMap);
			return typeMap;
		}

		static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
	}
}