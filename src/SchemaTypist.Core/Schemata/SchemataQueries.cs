using SchemaTypist.Core.Config;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.SqlKata;
using SqlKata;
using static SchemaTypist.Core.Schemata.Mapping.InformationSchema;

namespace SchemaTypist.Core.Schemata
{
    class SchemataQueries
    {
        private readonly CodeGenConfig _config;

        public SchemataQueries(CodeGenConfig config)
        {
            _config = config;
        }

        public Query InspectTables()
        {
            /*
             var q = new Query()
                .Select("c.TABLE_CATALOG", "c.TABLE_SCHEMA", "c.TABLE_NAME",
                        "c.ORDINAL_POSITION", "c.COLUMN_NAME", "c.DATA_TYPE",
                        "c.CHARACTER_MAXIMUM_LENGTH", "c.NUMERIC_PRECISION", "c.NUMERIC_SCALE",
                        "c.IS_NULLABLE")
                .From("INFORMATION_SCHEMA.COLUMNS as c")
                .LeftJoin("INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc",
                    j => j
                        .On("c.TABLE_CATALOG", "tc.CONSTRAINT_CATALOG")
                        .On("c.TABLE_SCHEMA", "tc.CONSTRAINT_SCHEMA")
                        .On("c.TABLE_NAME", "tc.TABLE_NAME").Where("tc.CONSTRAINT_TYPE", "=", "PRIMARY KEY"))
                .LeftJoin("INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE as tcu",
                    j => j
                        .On("tc.CONSTRAINT_NAME", "tcu.CONSTRAINT_NAME")
                        .On("c.COLUMN_NAME", "tcu.COLUMN_NAME"))
                .OrderBy("c.TABLE_CATALOG", "c.TABLE_SCHEMA", "c.TABLE_NAME","c.COLUMN_NAME")
                ;
            */
            var c = Columns.Table.As("c");
            var tc = TableConstraints.Table.As("tc");

            var q = new Query()
                .Select(c.TableCatalog, c.TableSchema, c.TableName,
                        c.OrdinalPosition, c.ColumnName, c.DataType,
                        c.CharacterMaximumLength, c.NumericPrecision, c.NumericScale,
                        c.IsNullable)
                .From(c)
                .LeftJoin(tc, 
                    j => j
                        .On(c.TableCatalog, tc.ConstraintCatalog)
                        .On(c.TableSchema, tc.ConstraintSchema)
                        .On(c.TableName, tc.TableName).Where(tc.ConstraintType, Op.EQ, "PRIMARY KEY"))
                .OrderBy(c.TableCatalog, c.TableSchema, c.TableName, c.ColumnName);
                
            return q;
        }
    }

}
