using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Dml
{
    public interface IDmlArgumentsValidator
    {
        bool IsValid(ColumnDefinition column, object val);
    }
}