using System;
using System.Collections.Generic;
using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Dml
{
    public interface IDmlArgumentsGenerator
    {
        Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>> GenerateArgsForInsert(object entity);
        Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>> GenerateArgsForUpdate(object entity);
    }

    public interface IDmlArgumentsGenerator<in TEntity> : IDmlArgumentsGenerator
    {
        Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>> GenerateArgsForInsert(TEntity entity);
        Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>> GenerateArgsForUpdate(TEntity entity);
    }
}