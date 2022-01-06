using System.Collections.Generic;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Naming
{
    internal interface INamingService
    {
        string ConvertCatalogName(string sqlCatalogName, CodeGenConfig config);
        string ConvertSchemaName(string sqlSchemaName, CodeGenConfig config, string enclosingType);
        string ConvertTableName(string sqlTableName, CodeGenConfig config, string enclosingType);
        string ConvertColumnName(string sqlColumnName, CodeGenConfig config, HashSet<string> additionalNamesToAvoid);
    }
}
