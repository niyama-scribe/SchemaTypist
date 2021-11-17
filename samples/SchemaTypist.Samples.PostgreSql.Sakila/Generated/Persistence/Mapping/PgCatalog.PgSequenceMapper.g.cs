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
	static partial class PgCatalog
	{
		public static partial class PgSequenceMapper
		{
			static partial class Constants
			{
				public const string CacheSize = "cache_size";
				public const string Cycle = "cycle";
				public const string DataType = "data_type";
				public const string IncrementBy = "increment_by";
				public const string LastValue = "last_value";
				public const string MaxValue = "max_value";
				public const string MinValue = "min_value";
				public const string Schemaname = "schemaname";
				public const string Sequencename = "sequencename";
				public const string Sequenceowner = "sequenceowner";
				public const string StartValue = "start_value";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_sequences")
				{
					CacheSize = new ColumnDefinition(Constants.CacheSize, this);
					Cycle = new ColumnDefinition(Constants.Cycle, this);
					DataType = new ColumnDefinition(Constants.DataType, this);
					IncrementBy = new ColumnDefinition(Constants.IncrementBy, this);
					LastValue = new ColumnDefinition(Constants.LastValue, this);
					MaxValue = new ColumnDefinition(Constants.MaxValue, this);
					MinValue = new ColumnDefinition(Constants.MinValue, this);
					Schemaname = new ColumnDefinition(Constants.Schemaname, this);
					Sequencename = new ColumnDefinition(Constants.Sequencename, this);
					Sequenceowner = new ColumnDefinition(Constants.Sequenceowner, this);
					StartValue = new ColumnDefinition(Constants.StartValue, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition CacheSize { get; private set; }
				public ColumnDefinition Cycle { get; private set; }
				public ColumnDefinition DataType { get; private set; }
				public ColumnDefinition IncrementBy { get; private set; }
				public ColumnDefinition LastValue { get; private set; }
				public ColumnDefinition MaxValue { get; private set; }
				public ColumnDefinition MinValue { get; private set; }
				public ColumnDefinition Schemaname { get; private set; }
				public ColumnDefinition Sequencename { get; private set; }
				public ColumnDefinition Sequenceowner { get; private set; }
				public ColumnDefinition StartValue { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.CacheSize, nameof(PgSequence.CacheSize) },
					{Constants.Cycle, nameof(PgSequence.Cycle) },
					{Constants.DataType, nameof(PgSequence.DataType) },
					{Constants.IncrementBy, nameof(PgSequence.IncrementBy) },
					{Constants.LastValue, nameof(PgSequence.LastValue) },
					{Constants.MaxValue, nameof(PgSequence.MaxValue) },
					{Constants.MinValue, nameof(PgSequence.MinValue) },
					{Constants.Schemaname, nameof(PgSequence.Schemaname) },
					{Constants.Sequencename, nameof(PgSequence.Sequencename) },
					{Constants.Sequenceowner, nameof(PgSequence.Sequenceowner) },
					{Constants.StartValue, nameof(PgSequence.StartValue) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgSequence), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}