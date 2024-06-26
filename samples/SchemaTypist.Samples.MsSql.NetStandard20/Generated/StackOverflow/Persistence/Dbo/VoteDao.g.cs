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
using SchemaTypist.Samples.MsSql.Generated.StackOverflow.Domain.Dbo;

namespace SchemaTypist.Samples.MsSql.Generated.StackOverflow.Persistence.Dbo
{
	public static partial class VoteDao
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
			private readonly IDictionary<string, ColumnDefinition> _columns = new Dictionary<string, ColumnDefinition>();
                
			public TableDefinition() : base("StackOverflow.dbo.Votes")
			{
				_columns.Add(Constants.BountyAmount, new ColumnDefinition(Constants.BountyAmount, this));
				_columns.Add(Constants.CreationDate, new ColumnDefinition(Constants.CreationDate, this));
				_columns.Add(Constants.Id, new ColumnDefinition(Constants.Id, this));
				_columns.Add(Constants.PostId, new ColumnDefinition(Constants.PostId, this));
				_columns.Add(Constants.UserId, new ColumnDefinition(Constants.UserId, this));
				_columns.Add(Constants.VoteTypeId, new ColumnDefinition(Constants.VoteTypeId, this));
			}

			public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

			public ColumnDefinition BountyAmount => _columns[Constants.BountyAmount];
			public ColumnDefinition CreationDate => _columns[Constants.CreationDate];
			public ColumnDefinition Id => _columns[Constants.Id];
			public ColumnDefinition PostId => _columns[Constants.PostId];
			public ColumnDefinition UserId => _columns[Constants.UserId];
			public ColumnDefinition VoteTypeId => _columns[Constants.VoteTypeId];

			public IEnumerable<ColumnDefinition> Star => _columns.Values;
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