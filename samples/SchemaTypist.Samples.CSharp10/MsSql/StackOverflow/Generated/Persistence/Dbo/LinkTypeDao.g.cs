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
using SchemaTypistSamples.MsSql.StackOverflow.Generated.Domain.Dbo;

namespace SchemaTypistSamples.MsSql.StackOverflow.Generated.Persistence.Dbo
{
	public static partial class LinkTypeDao
	{
		static partial class Constants
		{
			public const string Id = "Id";
			public const string Type = "Type";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			public TableDefinition() : base("StackOverflow.dbo.LinkTypes")
			{
				Id = new ColumnDefinition(Constants.Id, this);
				Type = new ColumnDefinition(Constants.Type, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition Id { get; private set; }
			public ColumnDefinition Type { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.Id, nameof(LinkType.Id) },
				{Constants.Type, nameof(LinkType.Type) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(LinkType), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}