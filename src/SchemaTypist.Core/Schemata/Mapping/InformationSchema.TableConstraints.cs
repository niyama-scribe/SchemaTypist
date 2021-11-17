using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Core.Schemata.Mapping
{
    static partial class InformationSchema
    {
        public static partial class TableConstraints
        {
            public static partial class Constants
            {
                public const string ConstraintCatalog = "constraint_catalog";
                public const string ConstraintSchema = "constraint_schema";
                public const string TableName = "table_name";
                public const string ConstraintType = "constraint_type";
            }

            public static TableDefinition Table => new TableDefinition();

            public partial class TableDefinition : TabularDefinition
            {
                public TableDefinition() : base("information_schema.table_constraints")
                {
                    ConstraintCatalog = new ColumnDefinition(Constants.ConstraintCatalog, this);
                    ConstraintSchema = new ColumnDefinition(Constants.ConstraintSchema, this);
                    TableName = new ColumnDefinition(Constants.TableName, this);
                    ConstraintType = new ColumnDefinition(Constants.ConstraintType, this);
                }

                public TableDefinition As(string alias) => base.As<TableDefinition>(alias);

                public ColumnDefinition ConstraintCatalog { get; private set; }
                public ColumnDefinition ConstraintSchema { get; private set; }
                public ColumnDefinition TableName { get; private set; }
                public ColumnDefinition ConstraintType { get; private set; }

            }
        }
    }
}
