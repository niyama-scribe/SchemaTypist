using System;
using System.Collections.Generic;

namespace SchemaTypist.Dml
{
    public static class DmlMapper
    {
        private static readonly Dictionary<Type, IDmlArgumentsGenerator> DmlMap =
            new Dictionary<Type, IDmlArgumentsGenerator>();
        public static void SetDmlArgsGenerator<TEntity>(IDmlArgumentsGenerator<TEntity> dmlArgumentsGenerator)
        {
            DmlMap.Add(typeof(TEntity), dmlArgumentsGenerator);
        }
        
        internal static bool TryGetDmlArgumentsGenerator<T>(out IDmlArgumentsGenerator dmlArgsGenerator)
        {
            return DmlMap.TryGetValue(typeof(T), out dmlArgsGenerator);
        }
    }
}