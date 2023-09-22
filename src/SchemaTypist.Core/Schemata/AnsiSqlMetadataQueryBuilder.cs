using SchemaTypist.Core.SqlVendors;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.SqlKata;
using SqlKata;
using static SchemaTypist.Core.Schemata.Mapping.InformationSchema;

namespace SchemaTypist.Core.Schemata
{
    /// <summary>
    /// This represents standardized, vendor-agnostic queries for database metadata inspection.
    /// </summary>
    public abstract class AnsiSqlMetadataQueryBuilder : IMetadataQueryBuilder
    {
        public Query BuildTablesQuery()
        {
            var c = Columns.Table.As("c");
            var tc = TableConstraints.Table.As("tc");

            var q = new Query()
                .Select(c.Star, c.CharacterMaximumLength)
                .From(c)
                .LeftJoin(tc, 
                    j => j
                        .On(c.TableCatalog, tc.ConstraintCatalog)
                        .On(c.TableSchema, tc.ConstraintSchema)
                        .On(c.TableName, tc.TableName).Where(tc.ConstraintType, Op.EQ, "PRIMARY KEY"))
                .OrderBy(c.TableCatalog, c.TableSchema, c.TableName, c.ColumnName);
                
            return q;
        }

        public abstract Query BuildRoutinesQuery();
        public abstract Query BuildTableValuedParametersQuery();
        public abstract Query BuildRoutinesReturnTypesQuery();
    }
}