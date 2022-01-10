using System.Data;

namespace SchemaTypist.Samples.NetStandard20.MsSql
{
    public abstract class MsSqlRepository : BaseRepository
    {
        private static readonly RepositoryConnector RepositoryType = RepositoryConnector.MsSql;

        protected MsSqlRepository(string connectionString, int timeout = 30) : base(RepositoryType, connectionString, timeout)
        {
        }

        protected MsSqlRepository(IDbConnection dbConnection, int timeout = 30) : base(RepositoryType, dbConnection, timeout)
        {
        }
    }
}
