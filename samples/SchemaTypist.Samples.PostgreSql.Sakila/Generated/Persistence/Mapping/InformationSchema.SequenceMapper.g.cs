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
		public static partial class SequenceMapper
		{
			static partial class Constants
			{
				public const string CycleOption = "cycle_option";
				public const string DataType = "data_type";
				public const string Increment = "increment";
				public const string MaximumValue = "maximum_value";
				public const string MinimumValue = "minimum_value";
				public const string NumericPrecision = "numeric_precision";
				public const string NumericPrecisionRadix = "numeric_precision_radix";
				public const string NumericScale = "numeric_scale";
				public const string SequenceCatalog = "sequence_catalog";
				public const string SequenceName = "sequence_name";
				public const string SequenceSchema = "sequence_schema";
				public const string StartValue = "start_value";
			}

			public static TableDefinition Table => new TableDefinition();

			public partial class TableDefinition : TabularDefinition
			{
				public TableDefinition() : base("information_schema.sequences")
				{
					CycleOption = new ColumnDefinition(Constants.CycleOption, this);
					DataType = new ColumnDefinition(Constants.DataType, this);
					Increment = new ColumnDefinition(Constants.Increment, this);
					MaximumValue = new ColumnDefinition(Constants.MaximumValue, this);
					MinimumValue = new ColumnDefinition(Constants.MinimumValue, this);
					NumericPrecision = new ColumnDefinition(Constants.NumericPrecision, this);
					NumericPrecisionRadix = new ColumnDefinition(Constants.NumericPrecisionRadix, this);
					NumericScale = new ColumnDefinition(Constants.NumericScale, this);
					SequenceCatalog = new ColumnDefinition(Constants.SequenceCatalog, this);
					SequenceName = new ColumnDefinition(Constants.SequenceName, this);
					SequenceSchema = new ColumnDefinition(Constants.SequenceSchema, this);
					StartValue = new ColumnDefinition(Constants.StartValue, this);
				}

				public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

				public ColumnDefinition CycleOption { get; private set; }
				public ColumnDefinition DataType { get; private set; }
				public ColumnDefinition Increment { get; private set; }
				public ColumnDefinition MaximumValue { get; private set; }
				public ColumnDefinition MinimumValue { get; private set; }
				public ColumnDefinition NumericPrecision { get; private set; }
				public ColumnDefinition NumericPrecisionRadix { get; private set; }
				public ColumnDefinition NumericScale { get; private set; }
				public ColumnDefinition SequenceCatalog { get; private set; }
				public ColumnDefinition SequenceName { get; private set; }
				public ColumnDefinition SequenceSchema { get; private set; }
				public ColumnDefinition StartValue { get; private set; }

			}
		
			public static partial class QueryResults
			{
				private static Dictionary<string, string> columnMap = new Dictionary<string, string>()
				{
					{Constants.CycleOption, nameof(Sequence.CycleOption) },
					{Constants.DataType, nameof(Sequence.DataType) },
					{Constants.Increment, nameof(Sequence.Increment) },
					{Constants.MaximumValue, nameof(Sequence.MaximumValue) },
					{Constants.MinimumValue, nameof(Sequence.MinimumValue) },
					{Constants.NumericPrecision, nameof(Sequence.NumericPrecision) },
					{Constants.NumericPrecisionRadix, nameof(Sequence.NumericPrecisionRadix) },
					{Constants.NumericScale, nameof(Sequence.NumericScale) },
					{Constants.SequenceCatalog, nameof(Sequence.SequenceCatalog) },
					{Constants.SequenceName, nameof(Sequence.SequenceName) },
					{Constants.SequenceSchema, nameof(Sequence.SequenceSchema) },
					{Constants.StartValue, nameof(Sequence.StartValue) },
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
					var typeMap = new CustomPropertyTypeMap(typeof(Sequence), GetMapperFunc());
					CustomizeTypeMap(typeMap);
					return typeMap;
				}

				static partial void CustomizeTypeMap(CustomPropertyTypeMap typeMap);
			}
		}
	}
}