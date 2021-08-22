using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaTypist.Core.DatabaseMetadata
{
    public partial class ColumnDefinition : IAliasable
    {
        public ColumnDefinition(string columnName, TabularDefinition belongsTo)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException(nameof(columnName));

            ColumnName__ = columnName;
            BelongsTo__ = belongsTo;
        }

        public T As<T>(string alias) where T : ColumnDefinition
        {
            Alias__ = alias;
            return (T)this;
        }

        public virtual TabularDefinition BelongsTo__ { get; private set; }
        public virtual string ColumnName__ { get; private set; }
        public virtual string Alias__ { get; private set; }
        public virtual string QualifiedName__ => $"{BelongsTo__.Usage__}.{ColumnName__}";
        public virtual string Declaration__ => AliasableDefaults.Declare(this);
        public virtual string Usage__ => AliasableDefaults.Use(this);
    }
}
