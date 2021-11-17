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
	static partial class InformationSchema
	{
		public static partial class UsagePrivilegeMapper
		{
			static partial class Constants
			{
				public const string Grantee = "grantee";
				public const string Grantor = "grantor";
				public const string IsGrantable = "is_grantable";
				public const string ObjectCatalog = "object_catalog";
				public const string ObjectName = "object_name";
				public const string ObjectSchema = "object_schema";
				public const string ObjectType = "object_type";
				public const string PrivilegeType = "privilege_type";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.usage_privileges")
				{
					Grantee = new ColumnDefinition(Constants.Grantee, this);
					Grantor = new ColumnDefinition(Constants.Grantor, this);
					IsGrantable = new ColumnDefinition(Constants.IsGrantable, this);
					ObjectCatalog = new ColumnDefinition(Constants.ObjectCatalog, this);
					ObjectName = new ColumnDefinition(Constants.ObjectName, this);
					ObjectSchema = new ColumnDefinition(Constants.ObjectSchema, this);
					ObjectType = new ColumnDefinition(Constants.ObjectType, this);
					PrivilegeType = new ColumnDefinition(Constants.PrivilegeType, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Grantee { get; private set; }
				public ColumnDefinition Grantor { get; private set; }
				public ColumnDefinition IsGrantable { get; private set; }
				public ColumnDefinition ObjectCatalog { get; private set; }
				public ColumnDefinition ObjectName { get; private set; }
				public ColumnDefinition ObjectSchema { get; private set; }
				public ColumnDefinition ObjectType { get; private set; }
				public ColumnDefinition PrivilegeType { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Grantee, nameof(UsagePrivilege.Grantee) },
					{Constants.Grantor, nameof(UsagePrivilege.Grantor) },
					{Constants.IsGrantable, nameof(UsagePrivilege.IsGrantable) },
					{Constants.ObjectCatalog, nameof(UsagePrivilege.ObjectCatalog) },
					{Constants.ObjectName, nameof(UsagePrivilege.ObjectName) },
					{Constants.ObjectSchema, nameof(UsagePrivilege.ObjectSchema) },
					{Constants.ObjectType, nameof(UsagePrivilege.ObjectType) },
					{Constants.PrivilegeType, nameof(UsagePrivilege.PrivilegeType) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(UsagePrivilege), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}