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
		public static partial class ApplicableRoleMapper
		{
			static partial class Constants
			{
				public const string Grantee = "grantee";
				public const string IsGrantable = "is_grantable";
				public const string RoleName = "role_name";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.applicable_roles")
				{
					Grantee = new ColumnDefinition(Constants.Grantee, this);
					IsGrantable = new ColumnDefinition(Constants.IsGrantable, this);
					RoleName = new ColumnDefinition(Constants.RoleName, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition Grantee { get; private set; }
				public ColumnDefinition IsGrantable { get; private set; }
				public ColumnDefinition RoleName { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.Grantee, nameof(ApplicableRole.Grantee) },
					{Constants.IsGrantable, nameof(ApplicableRole.IsGrantable) },
					{Constants.RoleName, nameof(ApplicableRole.RoleName) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(ApplicableRole), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}