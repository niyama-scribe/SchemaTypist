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
	public static partial class PostLinkDao
	{
		static partial class Constants
		{
			public const string CreationDate = "CreationDate";
			public const string Id = "Id";
			public const string LinkTypeId = "LinkTypeId";
			public const string PostId = "PostId";
			public const string RelatedPostId = "RelatedPostId";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			public TableDefinition() : base("StackOverflow.dbo.PostLinks")
			{
				CreationDate = new ColumnDefinition(Constants.CreationDate, this);
				Id = new ColumnDefinition(Constants.Id, this);
				LinkTypeId = new ColumnDefinition(Constants.LinkTypeId, this);
				PostId = new ColumnDefinition(Constants.PostId, this);
				RelatedPostId = new ColumnDefinition(Constants.RelatedPostId, this);
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition CreationDate { get; private set; }
			public ColumnDefinition Id { get; private set; }
			public ColumnDefinition LinkTypeId { get; private set; }
			public ColumnDefinition PostId { get; private set; }
			public ColumnDefinition RelatedPostId { get; private set; }

		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.CreationDate, nameof(PostLink.CreationDate) },
				{Constants.Id, nameof(PostLink.Id) },
				{Constants.LinkTypeId, nameof(PostLink.LinkTypeId) },
				{Constants.PostId, nameof(PostLink.PostId) },
				{Constants.RelatedPostId, nameof(PostLink.RelatedPostId) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(PostLink), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}