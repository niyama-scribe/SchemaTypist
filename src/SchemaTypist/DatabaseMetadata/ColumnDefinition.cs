using System;

namespace SchemaTypist.DatabaseMetadata
{
    public partial class ColumnDefinition
    {
        private readonly AliasableColumnDefinition _aliasable;
        public ColumnDefinition(string columnName, TabularDefinition belongsTo, ColumnMetadata metadata = null)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException(nameof(columnName));
            Metadata = metadata;

            _aliasable = new AliasableColumnDefinition(columnName, belongsTo);
        }

        public T As<T>(string alias) where T : ColumnDefinition
        {
            Alias__ = alias;
            return (T)this;
        }

        internal TabularDefinition BelongsTo__ => _aliasable.BelongsTo__;
        internal string ColumnName__ => _aliasable.ColumnName__;
        internal string Alias__
        {
            get => _aliasable.Alias__;
            set => _aliasable.Alias__ = value;
        }
        internal string QualifiedName__ => _aliasable.QualifiedName__;
        internal string Declaration__ => AliasableDefaults.Declare(_aliasable);
        internal string Usage__ => AliasableDefaults.Use(_aliasable);
        internal ColumnMetadata Metadata { get; }
        
        private class AliasableColumnDefinition : IAliasable
        {
            public string ColumnName__ { get; }
            public TabularDefinition BelongsTo__ { get; }

            public AliasableColumnDefinition(string columnName, TabularDefinition belongsTo)
            {
                ColumnName__ = columnName;
                BelongsTo__ = belongsTo;
            }

            public string QualifiedName__ => $"{BelongsTo__.Usage__}.{ColumnName__}";
            public string Alias__ { get; set; }
        }
    }
}
