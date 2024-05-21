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
using SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Domain.Public;

namespace SchemaTypist.Samples.Postgres.NetCore.Sakila.Generated.Persistence.Public
{
	public static partial class ActorDao
	{
		static partial class Constants
		{
			public const string ActorId = "actor_id";
			public const string FirstName = "first_name";
			public const string LastName = "last_name";
			public const string LastUpdate = "last_update";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("public.actor")
			{
				_columns.Add(Constants.ActorId, new ColumnDefinition(Constants.ActorId, this));
				_columns.Add(Constants.FirstName, new ColumnDefinition(Constants.FirstName, this));
				_columns.Add(Constants.LastName, new ColumnDefinition(Constants.LastName, this));
				_columns.Add(Constants.LastUpdate, new ColumnDefinition(Constants.LastUpdate, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition ActorId => _columns[Constants.ActorId];
			public ColumnDefinition FirstName => _columns[Constants.FirstName];
			public ColumnDefinition LastName => _columns[Constants.LastName];
			public ColumnDefinition LastUpdate => _columns[Constants.LastUpdate];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.ActorId, nameof(Actor.ActorId) },
				{Constants.FirstName, nameof(Actor.FirstName) },
				{Constants.LastName, nameof(Actor.LastName) },
				{Constants.LastUpdate, nameof(Actor.LastUpdate) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(Actor), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}