using System;
using System.Collections.Generic;
using SchemaTypist.DatabaseMetadata;

namespace SchemaTypist.Dml
{
    public class DmlArgumentsBuilder
    {
        private readonly List<ColumnDefinition> _columns = new List<ColumnDefinition>();
        private readonly List<object> _values = new List<object>();
        private readonly IDmlArgumentsValidator _validator;

        public DmlArgumentsBuilder(IDmlArgumentsValidator validator)
        {
            _validator = validator;
        }

        public DmlArgumentsBuilder With(ColumnDefinition column, object val)
        {
            if (_validator.IsValid(column, val))
            {
                _columns.Add(column);
                _values.Add(val);
            }

            return this;
        }

        public Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>> Build()
        {
            return new Tuple<IEnumerable<ColumnDefinition>, IEnumerable<object>>(_columns, _values);
        }
    }
}