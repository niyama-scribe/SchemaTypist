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

public static partial class PaymentP200704Dao
{
	static partial class Constants
	{
		public const string Amount = "amount";
		public const string CustomerId = "customer_id";
		public const string PaymentDate = "payment_date";
		public const string PaymentId = "payment_id";
		public const string RentalId = "rental_id";
		public const string StaffId = "staff_id";
	}

	public static TableDefinition Table => new TableDefinition();

	public partial class TableDefinition : TabularDefinition
	{
		private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
            
		public TableDefinition() : base("public.payment_p2007_04")
		{
			_columns.Add(Constants.Amount, new ColumnDefinition(Constants.Amount, this));
			_columns.Add(Constants.CustomerId, new ColumnDefinition(Constants.CustomerId, this));
			_columns.Add(Constants.PaymentDate, new ColumnDefinition(Constants.PaymentDate, this));
			_columns.Add(Constants.PaymentId, new ColumnDefinition(Constants.PaymentId, this));
			_columns.Add(Constants.RentalId, new ColumnDefinition(Constants.RentalId, this));
			_columns.Add(Constants.StaffId, new ColumnDefinition(Constants.StaffId, this));
		}

		public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

		public ColumnDefinition Amount => _columns[Constants.Amount];
		public ColumnDefinition CustomerId => _columns[Constants.CustomerId];
		public ColumnDefinition PaymentDate => _columns[Constants.PaymentDate];
		public ColumnDefinition PaymentId => _columns[Constants.PaymentId];
		public ColumnDefinition RentalId => _columns[Constants.RentalId];
		public ColumnDefinition StaffId => _columns[Constants.StaffId];

		public IEnumerable<ColumnDefinition> Star => _columns.Values;
	}

	public static partial class QueryResults
	{
		private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
		{
			{Constants.Amount, nameof(PaymentP200704.Amount) },
			{Constants.CustomerId, nameof(PaymentP200704.CustomerId) },
			{Constants.PaymentDate, nameof(PaymentP200704.PaymentDate) },
			{Constants.PaymentId, nameof(PaymentP200704.PaymentId) },
			{Constants.RentalId, nameof(PaymentP200704.RentalId) },
			{Constants.StaffId, nameof(PaymentP200704.StaffId) },
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
			var typeMap = new CustomPropertyTypeMap(typeof(PaymentP200704), GetMapperFunc());
			CustomizeTypeMap(typeMap);
			return typeMap;
		}

		static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
	}
}