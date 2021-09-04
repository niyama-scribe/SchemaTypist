using System;

namespace SchemaTypist.DatabaseMetadata
{
    public partial class TabularDefinition : IAliasable
    {
        public TabularDefinition(string catalogName, string schemaName, string tableName)
        {
            CatalogName__ = catalogName ?? throw new ArgumentNullException(nameof(catalogName));
            SchemaName__ = schemaName ?? throw new ArgumentNullException(nameof(schemaName));
            TableName__ = tableName ?? throw new ArgumentNullException(nameof(tableName));
            QualifiedName__ = $"{CatalogName__}.{SchemaName__}.{TableName__}";
        }

        protected virtual T As<T>(string alias) where T:TabularDefinition
        {
            Alias__ = alias;
            return (T)this;
        }

        public string CatalogName__ { get; private set; }
        public string SchemaName__ { get; private set; }
        public string TableName__ { get; private set; }
        public string Alias__ { get; private set; }
        public string QualifiedName__ { get; private set; }
        public virtual string Declaration__ => AliasableDefaults.Declare(this);
        public virtual string Usage__ => AliasableDefaults.Use(this);
    }

}
