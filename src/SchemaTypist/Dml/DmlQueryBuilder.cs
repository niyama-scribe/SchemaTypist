using SchemaTypist.SqlKata;
using SqlKata;

namespace SchemaTypist.Dml
{
    public static class DmlQueryBuilder
    {
        public static void BuildForInsert<TEntity>(Query q, TEntity entity)
        {
            if (!DmlMapper.TryGetDmlArgumentsGenerator<TEntity>(out var argsGenerator)) return;
            
            var args = argsGenerator.GenerateArgsForInsert(entity);
            q.AsInsert(args.Item1, args.Item2);
        }
        
        

        public static void BuildForUpdate<TEntity>(Query q, TEntity entity)
        {
            if (!DmlMapper.TryGetDmlArgumentsGenerator<TEntity>(out var argsGenerator)) return;
            
            var args = argsGenerator.GenerateArgsForUpdate(entity);
            q.AsInsert(args.Item1, args.Item2);
        }
    }
}