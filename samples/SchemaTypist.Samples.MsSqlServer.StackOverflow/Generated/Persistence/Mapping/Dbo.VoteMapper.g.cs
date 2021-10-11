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
	static partial class Dbo
	{
		public static partial class VoteMapper
		{
			static partial class Constants
			{
				public const string BountyAmount = "BountyAmount";
				public const string CreationDate = "CreationDate";
				public const string Id = "Id";
				public const string PostId = "PostId";
				public const string UserId = "UserId";
				public const string VoteTypeId = "VoteTypeId";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("StackOverflow.dbo.Votes")
				{
					BountyAmount = new ColumnDefinition(Constants.BountyAmount, this);
					CreationDate = new ColumnDefinition(Constants.CreationDate, this);
					Id = new ColumnDefinition(Constants.Id, this);
					PostId = new ColumnDefinition(Constants.PostId, this);
					UserId = new ColumnDefinition(Constants.UserId, this);
					VoteTypeId = new ColumnDefinition(Constants.VoteTypeId, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition BountyAmount { get; private set; }
				public ColumnDefinition CreationDate { get; private set; }
				public ColumnDefinition Id { get; private set; }
				public ColumnDefinition PostId { get; private set; }
				public ColumnDefinition UserId { get; private set; }
				public ColumnDefinition VoteTypeId { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.BountyAmount, nameof(Vote.BountyAmount) },
					{Constants.CreationDate, nameof(Vote.CreationDate) },
					{Constants.Id, nameof(Vote.Id) },
					{Constants.PostId, nameof(Vote.PostId) },
					{Constants.UserId, nameof(Vote.UserId) },
					{Constants.VoteTypeId, nameof(Vote.VoteTypeId) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(Vote), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}