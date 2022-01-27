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
using SchemaTypist.Samples.NetStandard20.MsSql.StackOverflow.Generated.Domain.Dbo;

namespace SchemaTypist.Samples.NetStandard20.MsSql.StackOverflow.Generated.Persistence.Dbo
{
	public static partial class PostWithTypeDao
	{
		static partial class Constants
		{
			public const string AcceptedAnswerId = "AcceptedAnswerId";
			public const string AnswerCount = "AnswerCount";
			public const string Body = "Body";
			public const string ClosedDate = "ClosedDate";
			public const string CommentCount = "CommentCount";
			public const string CommunityOwnedDate = "CommunityOwnedDate";
			public const string CreationDate = "CreationDate";
			public const string FavoriteCount = "FavoriteCount";
			public const string Halflife = "halflife";
			public const string Id = "Id";
			public const string LastActivityDate = "LastActivityDate";
			public const string LastEditDate = "LastEditDate";
			public const string LastEditorDisplayName = "LastEditorDisplayName";
			public const string LastEditorUserId = "LastEditorUserId";
			public const string OwnerUserId = "OwnerUserId";
			public const string ParentId = "ParentId";
			public const string PostTypeId = "PostTypeId";
			public const string Score = "Score";
			public const string Tag = "Tags";
			public const string Title = "Title";
			public const string Type = "Type";
			public const string ViewCount = "ViewCount";
		}

		public static TableDefinition Table => new TableDefinition();

		public partial class TableDefinition : TabularDefinition
		{
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("StackOverflow.dbo.PostWithType")
			{
				_columns.Add(Constants.AcceptedAnswerId, new ColumnDefinition(Constants.AcceptedAnswerId, this));
				_columns.Add(Constants.AnswerCount, new ColumnDefinition(Constants.AnswerCount, this));
				_columns.Add(Constants.Body, new ColumnDefinition(Constants.Body, this));
				_columns.Add(Constants.ClosedDate, new ColumnDefinition(Constants.ClosedDate, this));
				_columns.Add(Constants.CommentCount, new ColumnDefinition(Constants.CommentCount, this));
				_columns.Add(Constants.CommunityOwnedDate, new ColumnDefinition(Constants.CommunityOwnedDate, this));
				_columns.Add(Constants.CreationDate, new ColumnDefinition(Constants.CreationDate, this));
				_columns.Add(Constants.FavoriteCount, new ColumnDefinition(Constants.FavoriteCount, this));
				_columns.Add(Constants.Halflife, new ColumnDefinition(Constants.Halflife, this));
				_columns.Add(Constants.Id, new ColumnDefinition(Constants.Id, this));
				_columns.Add(Constants.LastActivityDate, new ColumnDefinition(Constants.LastActivityDate, this));
				_columns.Add(Constants.LastEditDate, new ColumnDefinition(Constants.LastEditDate, this));
				_columns.Add(Constants.LastEditorDisplayName, new ColumnDefinition(Constants.LastEditorDisplayName, this));
				_columns.Add(Constants.LastEditorUserId, new ColumnDefinition(Constants.LastEditorUserId, this));
				_columns.Add(Constants.OwnerUserId, new ColumnDefinition(Constants.OwnerUserId, this));
				_columns.Add(Constants.ParentId, new ColumnDefinition(Constants.ParentId, this));
				_columns.Add(Constants.PostTypeId, new ColumnDefinition(Constants.PostTypeId, this));
				_columns.Add(Constants.Score, new ColumnDefinition(Constants.Score, this));
				_columns.Add(Constants.Tag, new ColumnDefinition(Constants.Tag, this));
				_columns.Add(Constants.Title, new ColumnDefinition(Constants.Title, this));
				_columns.Add(Constants.Type, new ColumnDefinition(Constants.Type, this));
				_columns.Add(Constants.ViewCount, new ColumnDefinition(Constants.ViewCount, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition AcceptedAnswerId => _columns[Constants.AcceptedAnswerId];
			public ColumnDefinition AnswerCount => _columns[Constants.AnswerCount];
			public ColumnDefinition Body => _columns[Constants.Body];
			public ColumnDefinition ClosedDate => _columns[Constants.ClosedDate];
			public ColumnDefinition CommentCount => _columns[Constants.CommentCount];
			public ColumnDefinition CommunityOwnedDate => _columns[Constants.CommunityOwnedDate];
			public ColumnDefinition CreationDate => _columns[Constants.CreationDate];
			public ColumnDefinition FavoriteCount => _columns[Constants.FavoriteCount];
			public ColumnDefinition Halflife => _columns[Constants.Halflife];
			public ColumnDefinition Id => _columns[Constants.Id];
			public ColumnDefinition LastActivityDate => _columns[Constants.LastActivityDate];
			public ColumnDefinition LastEditDate => _columns[Constants.LastEditDate];
			public ColumnDefinition LastEditorDisplayName => _columns[Constants.LastEditorDisplayName];
			public ColumnDefinition LastEditorUserId => _columns[Constants.LastEditorUserId];
			public ColumnDefinition OwnerUserId => _columns[Constants.OwnerUserId];
			public ColumnDefinition ParentId => _columns[Constants.ParentId];
			public ColumnDefinition PostTypeId => _columns[Constants.PostTypeId];
			public ColumnDefinition Score => _columns[Constants.Score];
			public ColumnDefinition Tag => _columns[Constants.Tag];
			public ColumnDefinition Title => _columns[Constants.Title];
			public ColumnDefinition Type => _columns[Constants.Type];
			public ColumnDefinition ViewCount => _columns[Constants.ViewCount];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
		}
	
		public static partial class QueryResults
		{
			private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
			{
				{Constants.AcceptedAnswerId, nameof(PostWithType.AcceptedAnswerId) },
				{Constants.AnswerCount, nameof(PostWithType.AnswerCount) },
				{Constants.Body, nameof(PostWithType.Body) },
				{Constants.ClosedDate, nameof(PostWithType.ClosedDate) },
				{Constants.CommentCount, nameof(PostWithType.CommentCount) },
				{Constants.CommunityOwnedDate, nameof(PostWithType.CommunityOwnedDate) },
				{Constants.CreationDate, nameof(PostWithType.CreationDate) },
				{Constants.FavoriteCount, nameof(PostWithType.FavoriteCount) },
				{Constants.Halflife, nameof(PostWithType.Halflife) },
				{Constants.Id, nameof(PostWithType.Id) },
				{Constants.LastActivityDate, nameof(PostWithType.LastActivityDate) },
				{Constants.LastEditDate, nameof(PostWithType.LastEditDate) },
				{Constants.LastEditorDisplayName, nameof(PostWithType.LastEditorDisplayName) },
				{Constants.LastEditorUserId, nameof(PostWithType.LastEditorUserId) },
				{Constants.OwnerUserId, nameof(PostWithType.OwnerUserId) },
				{Constants.ParentId, nameof(PostWithType.ParentId) },
				{Constants.PostTypeId, nameof(PostWithType.PostTypeId) },
				{Constants.Score, nameof(PostWithType.Score) },
				{Constants.Tag, nameof(PostWithType.Tag) },
				{Constants.Title, nameof(PostWithType.Title) },
				{Constants.Type, nameof(PostWithType.Type) },
				{Constants.ViewCount, nameof(PostWithType.ViewCount) },
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
				var typeMap = new CustomPropertyTypeMap(typeof(PostWithType), GetMapperFunc());
				CustomizeTypeMap(typeMap);
				return typeMap;
			}

			static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
		}
	}
}