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
using SchemaTypistSamples.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypistSamples.Postgres.Sakila.Generated.Persistence.Public
{
	public static partial class PaymentP200703Dao
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
			public TableDefinition() : base("public.payment_p2007_03")
			{
				Amount = new ColumnDefinition(Constants.Amount, this);
				CustomerId = new ColumnDefinition(Constants.CustomerId, this);
				PaymentDate = new ColumnDefinition(Constants.PaymentDate, this);
				PaymentId = new ColumnDefinition(Constants.PaymentId, this);
				RentalId = new ColumnDefinition(Constants.RentalId, this);
				StaffId = new ColumnDefinition(Constants.StaffId, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition Amount { get; private set; }
			public ColumnDefinition CustomerId { get; private set; }
			public ColumnDefinition PaymentDate { get; private set; }
			public ColumnDefinition PaymentId { get; private set; }
			public ColumnDefinition RentalId { get; private set; }
			public ColumnDefinition StaffId { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.Amount, nameof(PaymentP200703.Amount) },
				{Constants.CustomerId, nameof(PaymentP200703.CustomerId) },
				{Constants.PaymentDate, nameof(PaymentP200703.PaymentDate) },
				{Constants.PaymentId, nameof(PaymentP200703.PaymentId) },
				{Constants.RentalId, nameof(PaymentP200703.RentalId) },
				{Constants.StaffId, nameof(PaymentP200703.StaffId) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(PaymentP200703), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}