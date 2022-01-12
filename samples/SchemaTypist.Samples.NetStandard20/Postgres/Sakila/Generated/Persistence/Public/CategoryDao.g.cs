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
using SchemaTypist.Samples.NetStandard20.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypist.Samples.NetStandard20.Postgres.Sakila.Generated.Persistence.Public
{
	public static partial class CategoryDao
	{
		static partial class Constants
		{
			public const string CategoryId = "category_id";
			public const string LastUpdate = "last_update";
			public const string Name = "name";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("public.category")
			{
				_columns.Add(Constants.CategoryId, new ColumnDefinition(Constants.CategoryId, this));
				_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
				_columns.Add(Constants.Name, new ColumnDefinition(Constants.Name, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition CategoryId => _columns[Constants.CategoryId];
			public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];
			public ColumnDefinition Name => _columns[Constants.Name];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.CategoryId, nameof(Category.CategoryId) },
				{Constants.LastUpdate, nameof(Category.LastUpdate) },
				{Constants.Name, nameof(Category.Name) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Category), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}