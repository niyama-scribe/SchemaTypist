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
using SchemaTypist.Samples.NetStandard20.StackOverflow.Generated.Domain.Dbo;

namespace SchemaTypist.Samples.NetStandard20.StackOverflow.Generated.Persistence.Dbo
{
	public static partial class VoteTypeDao
	{
		static partial class Constants
		{
			public const string Id = "Id";
			public const string Name = "Name";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			public TableDefinition() : base("StackOverflow.dbo.VoteTypes")
			{
				Id = new ColumnDefinition(Constants.Id, this);
				Name = new ColumnDefinition(Constants.Name, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition Id { get; private set; }
			public ColumnDefinition Name { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.Id, nameof(VoteType.Id) },
				{Constants.Name, nameof(VoteType.Name) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(VoteType), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}