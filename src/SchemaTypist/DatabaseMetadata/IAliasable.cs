namespace SchemaTypist.DatabaseMetadata
{
    internal interface IAliasable
    {
        string QualifiedName__ { get; }
        string Alias__ { get; }
    }

    static class AliasableDefaults
    {
        public static string Declare(IAliasable a) => !string.IsNullOrEmpty(a.Alias__) ? $"{a.QualifiedName__} as {a.Alias__}" : a.QualifiedName__;
        public static string Use(IAliasable a) => !string.IsNullOrEmpty(a.Alias__) ? a.Alias__ : a.QualifiedName__;
    }
}
