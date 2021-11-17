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
		public static partial class PgShmemAllocationMapper
		{
			static partial class Constants
			{
				public const string AllocatedSize = "allocated_size";
				public const string Name = "name";
				public const string Off = "off";
				public const string Size = "size";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("pg_catalog.pg_shmem_allocations")
				{
					AllocatedSize = new ColumnDefinition(Constants.AllocatedSize, this);
					Name = new ColumnDefinition(Constants.Name, this);
					Off = new ColumnDefinition(Constants.Off, this);
					Size = new ColumnDefinition(Constants.Size, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition AllocatedSize { get; private set; }
				public ColumnDefinition Name { get; private set; }
				public ColumnDefinition Off { get; private set; }
				public ColumnDefinition Size { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.AllocatedSize, nameof(PgShmemAllocation.AllocatedSize) },
					{Constants.Name, nameof(PgShmemAllocation.Name) },
					{Constants.Off, nameof(PgShmemAllocation.Off) },
					{Constants.Size, nameof(PgShmemAllocation.Size) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(PgShmemAllocation), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}