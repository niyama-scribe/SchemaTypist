using System;

namespace SchemaTypist.DatabaseMetadata
{
    public partial class TabularDefinition
    {
        private AliasableTabularDefinition _aliasable = new();
        public TabularDefinition(string qualifiedName)
        {
            QualifiedName__ = qualifiedName ?? throw new ArgumentNullException(nameof(qualifiedName));
        }

        protected virtual T As<T>(string alias) where T:TabularDefinition
        {
            Alias__ = alias;
            return (T)this;
        }



        internal string QualifiedName__
        {
            get => _aliasable.QualifiedName__;
            private set => _aliasable.QualifiedName__ = value;
        }

        internal string Alias__
        {
            get => _aliasable.Alias__;
            private set => _aliasable.Alias__ = value;
        }

        internal string Declaration__ => AliasableDefaults.Declare(_aliasable);
        internal string Usage__ => AliasableDefaults.Use(_aliasable);

        private class AliasableTabularDefinition : IAliasable
        {
            public AliasableTabularDefinition()
            {

            }
            public string QualifiedName__ { get; set; }
            public string Alias__ { get; set; }
        }
    }

}
