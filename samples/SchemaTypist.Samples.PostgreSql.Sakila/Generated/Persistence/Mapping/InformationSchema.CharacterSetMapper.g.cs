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
		public static partial class CharacterSetMapper
		{
			static partial class Constants
			{
				public const string CharacterRepertoire = "character_repertoire";
				public const string CharacterSetCatalog = "character_set_catalog";
				public const string CharacterSetName = "character_set_name";
				public const string CharacterSetSchema = "character_set_schema";
				public const string DefaultCollateCatalog = "default_collate_catalog";
				public const string DefaultCollateName = "default_collate_name";
				public const string DefaultCollateSchema = "default_collate_schema";
				public const string FormOfUse = "form_of_use";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.character_sets")
				{
					CharacterRepertoire = new ColumnDefinition(Constants.CharacterRepertoire, this);
					CharacterSetCatalog = new ColumnDefinition(Constants.CharacterSetCatalog, this);
					CharacterSetName = new ColumnDefinition(Constants.CharacterSetName, this);
					CharacterSetSchema = new ColumnDefinition(Constants.CharacterSetSchema, this);
					DefaultCollateCatalog = new ColumnDefinition(Constants.DefaultCollateCatalog, this);
					DefaultCollateName = new ColumnDefinition(Constants.DefaultCollateName, this);
					DefaultCollateSchema = new ColumnDefinition(Constants.DefaultCollateSchema, this);
					FormOfUse = new ColumnDefinition(Constants.FormOfUse, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition CharacterRepertoire { get; private set; }
				public ColumnDefinition CharacterSetCatalog { get; private set; }
				public ColumnDefinition CharacterSetName { get; private set; }
				public ColumnDefinition CharacterSetSchema { get; private set; }
				public ColumnDefinition DefaultCollateCatalog { get; private set; }
				public ColumnDefinition DefaultCollateName { get; private set; }
				public ColumnDefinition DefaultCollateSchema { get; private set; }
				public ColumnDefinition FormOfUse { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.CharacterRepertoire, nameof(CharacterSet.CharacterRepertoire) },
					{Constants.CharacterSetCatalog, nameof(CharacterSet.CharacterSetCatalog) },
					{Constants.CharacterSetName, nameof(CharacterSet.CharacterSetName) },
					{Constants.CharacterSetSchema, nameof(CharacterSet.CharacterSetSchema) },
					{Constants.DefaultCollateCatalog, nameof(CharacterSet.DefaultCollateCatalog) },
					{Constants.DefaultCollateName, nameof(CharacterSet.DefaultCollateName) },
					{Constants.DefaultCollateSchema, nameof(CharacterSet.DefaultCollateSchema) },
					{Constants.FormOfUse, nameof(CharacterSet.FormOfUse) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(CharacterSet), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}