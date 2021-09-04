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
using System;
using System.Collections.Generic;
using System.Reflection;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Generated.Domain;

namespace SchemaTypist.Generated.Persistence
{
	static partial class Dbo
	{
		public static partial class VoteType
		{
			static partial class Constants
			{
				public const string Id = "Id";
				public const string Name = "Name";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("StackOverflow", "dbo", "VoteTypes")
				{
					Id = new ColumnDefinition(Constants.Id, this);
					Name = new ColumnDefinition(Constants.Name, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Id { get; private set; }
				public ColumnDefinition Name { get; private set; }

			}
		
			public static partial class QueryResultsMapper
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Id, nameof(VoteTypeEntity.Id) },
					{Constants.Name, nameof(VoteTypeEntity.Name) },
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

				public static CustomPropertyTypeMap GetMapper()
				{
					var typeMap = new CustomPropertyTypeMap(typeof(VoteTypeEntity), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}