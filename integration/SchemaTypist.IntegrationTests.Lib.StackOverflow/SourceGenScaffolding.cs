using System;

namespace SchemaTypist.IntegrationTests.Lib.StackOverflow
{
    /// <summary>
    /// Stuff needed by source generator to run SchemaTypist for StackOverflow
    /// </summary>
    public class SourceGenScaffolding
    {
        public string ImageName = "niyamascribe/stackoverflow-db";
        public string DbConnectionUserId = "sa";
        public string DbConnectionPwd = "N3v3r!nPr0d";
        public string DbConnectionInitialCatalog = "StackOverflow";

        //public string ConnectionString = "server=localhost;user id=sa;password=N3v3r!nPr0d;Database=StackOverflow";
    }
}
