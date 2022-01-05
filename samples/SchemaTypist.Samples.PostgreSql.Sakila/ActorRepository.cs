using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.Generated.Domain;
using SqlKata;
using SchemaTypist.SqlKata;
using static SchemaTypist.Generated.Persistence.Mapping.Public;

namespace SchemaTypist.Samples.PostgreSql.Sakila
{
    internal class ActorRepository : BaseRepository
    {
        public ActorRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        public ActorRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }

        public async Task<IEnumerable<Actor>> FindActorsByLastNameContaining(string input)
        {
            var a = ActorDao.Table.As("a");

            var q = new Query()
                .Select(a.FirstName, a.LastName)
                .From(a)
                .WhereContains(a.LastName, input);

            var results = await Database.GetAsync<Actor>(q);
            return results;
        }

        public async Task<IEnumerable<dynamic>> GetActorSharedLastNameStats()
        {
            var a = ActorDao.Table.As("a");
            var q = new Query()
                .Select(a.LastName)
                .SelectRaw("count(1) as \"actor_count\"")
                .From(a)
                .GroupBy(a.LastName)
                .HavingRaw("count(1) > 1")
                .OrderByDesc("actor_count")
                .OrderBy(a.LastName);

            var sql = Database.Compiler.Compile(q).Sql;
            Console.WriteLine(sql);
            var retVal = await Database.GetAsync(q);
            return retVal;
        }
    }
}
