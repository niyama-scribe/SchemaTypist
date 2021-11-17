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
		public static partial class CollationCharacterSetApplicabilityMapper
		{
			static partial class Constants
			{
				public const string CharacterSetCatalog = "character_set_catalog";
				public const string CharacterSetName = "character_set_name";
				public const string CharacterSetSchema = "character_set_schema";
				public const string CollationCatalog = "collation_catalog";
				public const string CollationName = "collation_name";
				public const string CollationSchema = "collation_schema";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.collation_character_set_applicability")
				{
					CharacterSetCatalog = new ColumnDefinition(Constants.CharacterSetCatalog, this);
					CharacterSetName = new ColumnDefinition(Constants.CharacterSetName, this);
					CharacterSetSchema = new ColumnDefinition(Constants.CharacterSetSchema, this);
					CollationCatalog = new ColumnDefinition(Constants.CollationCatalog, this);
					CollationName = new ColumnDefinition(Constants.CollationName, this);
					CollationSchema = new ColumnDefinition(Constants.CollationSchema, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition CharacterSetCatalog { get; private set; }
				public ColumnDefinition CharacterSetName { get; private set; }
				public ColumnDefinition CharacterSetSchema { get; private set; }
				public ColumnDefinition CollationCatalog { get; private set; }
				public ColumnDefinition CollationName { get; private set; }
				public ColumnDefinition CollationSchema { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.CharacterSetCatalog, nameof(CollationCharacterSetApplicability.CharacterSetCatalog) },
					{Constants.CharacterSetName, nameof(CollationCharacterSetApplicability.CharacterSetName) },
					{Constants.CharacterSetSchema, nameof(CollationCharacterSetApplicability.CharacterSetSchema) },
					{Constants.CollationCatalog, nameof(CollationCharacterSetApplicability.CollationCatalog) },
					{Constants.CollationName, nameof(CollationCharacterSetApplicability.CollationName) },
					{Constants.CollationSchema, nameof(CollationCharacterSetApplicability.CollationSchema) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(CollationCharacterSetApplicability), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}