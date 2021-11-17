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
		public static partial class ForeignDataWrapperMapper
		{
			static partial class Constants
			{
				public const string AuthorizationIdentifier = "authorization_identifier";
				public const string ForeignDataWrapperCatalog = "foreign_data_wrapper_catalog";
				public const string ForeignDataWrapperLanguage = "foreign_data_wrapper_language";
				public const string ForeignDataWrapperName = "foreign_data_wrapper_name";
				public const string LibraryName = "library_name";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.foreign_data_wrappers")
				{
					AuthorizationIdentifier = new ColumnDefinition(Constants.AuthorizationIdentifier, this);
					ForeignDataWrapperCatalog = new ColumnDefinition(Constants.ForeignDataWrapperCatalog, this);
					ForeignDataWrapperLanguage = new ColumnDefinition(Constants.ForeignDataWrapperLanguage, this);
					ForeignDataWrapperName = new ColumnDefinition(Constants.ForeignDataWrapperName, this);
					LibraryName = new ColumnDefinition(Constants.LibraryName, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition AuthorizationIdentifier { get; private set; }
				public ColumnDefinition ForeignDataWrapperCatalog { get; private set; }
				public ColumnDefinition ForeignDataWrapperLanguage { get; private set; }
				public ColumnDefinition ForeignDataWrapperName { get; private set; }
				public ColumnDefinition LibraryName { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.AuthorizationIdentifier, nameof(ForeignDataWrapper.AuthorizationIdentifier) },
					{Constants.ForeignDataWrapperCatalog, nameof(ForeignDataWrapper.ForeignDataWrapperCatalog) },
					{Constants.ForeignDataWrapperLanguage, nameof(ForeignDataWrapper.ForeignDataWrapperLanguage) },
					{Constants.ForeignDataWrapperName, nameof(ForeignDataWrapper.ForeignDataWrapperName) },
					{Constants.LibraryName, nameof(ForeignDataWrapper.LibraryName) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(ForeignDataWrapper), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}