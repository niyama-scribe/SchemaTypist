using System;

namespace SchemaTypist.DatabaseMetadata
{
    public partial class TabularDefinition : IAliasable
    {
        public TabularDefinition(string qualifiedName)
        {
            QualifiedName__ = qualifiedName ?? throw new ArgumentNullException(nameof(qualifiedName));
        }

        protected virtual T As<T>(string alias) where T:TabularDefinition
        {
            Alias__ = alias;
            return (T)this;
        }

        public string QualifiedName__ { get; private set; }
        public string Alias__ { get; private set; }
        public virtual string Declaration__ => AliasableDefaults.Declare(this);
        public virtual string Usage__ => AliasableDefaults.Use(this);
    }

}
