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
		public static partial class AttributeMapper
		{
			static partial class Constants
			{
				public const string AttributeDefault = "attribute_default";
				public const string AttributeName = "attribute_name";
				public const string AttributeUdtCatalog = "attribute_udt_catalog";
				public const string AttributeUdtName = "attribute_udt_name";
				public const string AttributeUdtSchema = "attribute_udt_schema";
				public const string CharacterMaximumLength = "character_maximum_length";
				public const string CharacterOctetLength = "character_octet_length";
				public const string CharacterSetCatalog = "character_set_catalog";
				public const string CharacterSetName = "character_set_name";
				public const string CharacterSetSchema = "character_set_schema";
				public const string CollationCatalog = "collation_catalog";
				public const string CollationName = "collation_name";
				public const string CollationSchema = "collation_schema";
				public const string DataType = "data_type";
				public const string DatetimePrecision = "datetime_precision";
				public const string DtdIdentifier = "dtd_identifier";
				public const string IntervalPrecision = "interval_precision";
				public const string IntervalType = "interval_type";
				public const string IsDerivedReferenceAttribute = "is_derived_reference_attribute";
				public const string IsNullable = "is_nullable";
				public const string MaximumCardinality = "maximum_cardinality";
				public const string NumericPrecision = "numeric_precision";
				public const string NumericPrecisionRadix = "numeric_precision_radix";
				public const string NumericScale = "numeric_scale";
				public const string OrdinalPosition = "ordinal_position";
				public const string ScopeCatalog = "scope_catalog";
				public const string ScopeName = "scope_name";
				public const string ScopeSchema = "scope_schema";
				public const string UdtCatalog = "udt_catalog";
				public const string UdtName = "udt_name";
				public const string UdtSchema = "udt_schema";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.attributes")
				{
					AttributeDefault = new ColumnDefinition(Constants.AttributeDefault, this);
					AttributeName = new ColumnDefinition(Constants.AttributeName, this);
					AttributeUdtCatalog = new ColumnDefinition(Constants.AttributeUdtCatalog, this);
					AttributeUdtName = new ColumnDefinition(Constants.AttributeUdtName, this);
					AttributeUdtSchema = new ColumnDefinition(Constants.AttributeUdtSchema, this);
					CharacterMaximumLength = new ColumnDefinition(Constants.CharacterMaximumLength, this);
					CharacterOctetLength = new ColumnDefinition(Constants.CharacterOctetLength, this);
					CharacterSetCatalog = new ColumnDefinition(Constants.CharacterSetCatalog, this);
					CharacterSetName = new ColumnDefinition(Constants.CharacterSetName, this);
					CharacterSetSchema = new ColumnDefinition(Constants.CharacterSetSchema, this);
					CollationCatalog = new ColumnDefinition(Constants.CollationCatalog, this);
					CollationName = new ColumnDefinition(Constants.CollationName, this);
					CollationSchema = new ColumnDefinition(Constants.CollationSchema, this);
					DataType = new ColumnDefinition(Constants.DataType, this);
					DatetimePrecision = new ColumnDefinition(Constants.DatetimePrecision, this);
					DtdIdentifier = new ColumnDefinition(Constants.DtdIdentifier, this);
					IntervalPrecision = new ColumnDefinition(Constants.IntervalPrecision, this);
					IntervalType = new ColumnDefinition(Constants.IntervalType, this);
					IsDerivedReferenceAttribute = new ColumnDefinition(Constants.IsDerivedReferenceAttribute, this);
					IsNullable = new ColumnDefinition(Constants.IsNullable, this);
					MaximumCardinality = new ColumnDefinition(Constants.MaximumCardinality, this);
					NumericPrecision = new ColumnDefinition(Constants.NumericPrecision, this);
					NumericPrecisionRadix = new ColumnDefinition(Constants.NumericPrecisionRadix, this);
					NumericScale = new ColumnDefinition(Constants.NumericScale, this);
					OrdinalPosition = new ColumnDefinition(Constants.OrdinalPosition, this);
					ScopeCatalog = new ColumnDefinition(Constants.ScopeCatalog, this);
					ScopeName = new ColumnDefinition(Constants.ScopeName, this);
					ScopeSchema = new ColumnDefinition(Constants.ScopeSchema, this);
					UdtCatalog = new ColumnDefinition(Constants.UdtCatalog, this);
					UdtName = new ColumnDefinition(Constants.UdtName, this);
					UdtSchema = new ColumnDefinition(Constants.UdtSchema, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition AttributeDefault { get; private set; }
				public ColumnDefinition AttributeName { get; private set; }
				public ColumnDefinition AttributeUdtCatalog { get; private set; }
				public ColumnDefinition AttributeUdtName { get; private set; }
				public ColumnDefinition AttributeUdtSchema { get; private set; }
				public ColumnDefinition CharacterMaximumLength { get; private set; }
				public ColumnDefinition CharacterOctetLength { get; private set; }
				public ColumnDefinition CharacterSetCatalog { get; private set; }
				public ColumnDefinition CharacterSetName { get; private set; }
				public ColumnDefinition CharacterSetSchema { get; private set; }
				public ColumnDefinition CollationCatalog { get; private set; }
				public ColumnDefinition CollationName { get; private set; }
				public ColumnDefinition CollationSchema { get; private set; }
				public ColumnDefinition DataType { get; private set; }
				public ColumnDefinition DatetimePrecision { get; private set; }
				public ColumnDefinition DtdIdentifier { get; private set; }
				public ColumnDefinition IntervalPrecision { get; private set; }
				public ColumnDefinition IntervalType { get; private set; }
				public ColumnDefinition IsDerivedReferenceAttribute { get; private set; }
				public ColumnDefinition IsNullable { get; private set; }
				public ColumnDefinition MaximumCardinality { get; private set; }
				public ColumnDefinition NumericPrecision { get; private set; }
				public ColumnDefinition NumericPrecisionRadix { get; private set; }
				public ColumnDefinition NumericScale { get; private set; }
				public ColumnDefinition OrdinalPosition { get; private set; }
				public ColumnDefinition ScopeCatalog { get; private set; }
				public ColumnDefinition ScopeName { get; private set; }
				public ColumnDefinition ScopeSchema { get; private set; }
				public ColumnDefinition UdtCatalog { get; private set; }
				public ColumnDefinition UdtName { get; private set; }
				public ColumnDefinition UdtSchema { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.AttributeDefault, nameof(Attribute.AttributeDefault) },
					{Constants.AttributeName, nameof(Attribute.AttributeName) },
					{Constants.AttributeUdtCatalog, nameof(Attribute.AttributeUdtCatalog) },
					{Constants.AttributeUdtName, nameof(Attribute.AttributeUdtName) },
					{Constants.AttributeUdtSchema, nameof(Attribute.AttributeUdtSchema) },
					{Constants.CharacterMaximumLength, nameof(Attribute.CharacterMaximumLength) },
					{Constants.CharacterOctetLength, nameof(Attribute.CharacterOctetLength) },
					{Constants.CharacterSetCatalog, nameof(Attribute.CharacterSetCatalog) },
					{Constants.CharacterSetName, nameof(Attribute.CharacterSetName) },
					{Constants.CharacterSetSchema, nameof(Attribute.CharacterSetSchema) },
					{Constants.CollationCatalog, nameof(Attribute.CollationCatalog) },
					{Constants.CollationName, nameof(Attribute.CollationName) },
					{Constants.CollationSchema, nameof(Attribute.CollationSchema) },
					{Constants.DataType, nameof(Attribute.DataType) },
					{Constants.DatetimePrecision, nameof(Attribute.DatetimePrecision) },
					{Constants.DtdIdentifier, nameof(Attribute.DtdIdentifier) },
					{Constants.IntervalPrecision, nameof(Attribute.IntervalPrecision) },
					{Constants.IntervalType, nameof(Attribute.IntervalType) },
					{Constants.IsDerivedReferenceAttribute, nameof(Attribute.IsDerivedReferenceAttribute) },
					{Constants.IsNullable, nameof(Attribute.IsNullable) },
					{Constants.MaximumCardinality, nameof(Attribute.MaximumCardinality) },
					{Constants.NumericPrecision, nameof(Attribute.NumericPrecision) },
					{Constants.NumericPrecisionRadix, nameof(Attribute.NumericPrecisionRadix) },
					{Constants.NumericScale, nameof(Attribute.NumericScale) },
					{Constants.OrdinalPosition, nameof(Attribute.OrdinalPosition) },
					{Constants.ScopeCatalog, nameof(Attribute.ScopeCatalog) },
					{Constants.ScopeName, nameof(Attribute.ScopeName) },
					{Constants.ScopeSchema, nameof(Attribute.ScopeSchema) },
					{Constants.UdtCatalog, nameof(Attribute.UdtCatalog) },
					{Constants.UdtName, nameof(Attribute.UdtName) },
					{Constants.UdtSchema, nameof(Attribute.UdtSchema) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(Attribute), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}