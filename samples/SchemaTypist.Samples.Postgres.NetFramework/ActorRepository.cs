using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Samples.Postgres.NetFramework.Postgres.Sakila.Generated.Domain.Public;
using SchemaTypist.Samples.Postgres.NetFramework.Postgres.Sakila.Generated.Persistence.Public;
using SchemaTypist.SqlKata;
using SqlKata;

namespace SchemaTypist.Samples.Postgres.NetFramework
{
    public class ActorRepository : PostgresRepository
    {
        public ActorRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }

        public ActorRepository(IDbConnection connection, int timeout = 30) : base(connection, timeout)
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

        public async Task<int> InsertActor(Actor actor)
        {
            var a = ActorDao.Table;
            var q = new Query()
                .For(a)
                .AsInsert(
                    new[] {a.FirstName, a.LastName},
                    new object[] {actor.FirstName, actor.LastName});

            var rowsAffected = await Database.ExecuteAsync(q);
            return rowsAffected;
        }

        public async Task<int> DeleteActor(int actorId)
        {
            var a = ActorDao.Table;
            var q = new Query()
                .AsDelete()
                .From(a)
                .Where(a.ActorId, Op.EQ, actorId);

            var rowsAffected = await Database.ExecuteAsync(q);
            return rowsAffected;
        }

        public async Task<Actor> GetByName(string firstName, string lastName)
        {
            var a = ActorDao.Table.As("a");

            var q = new Query()
                .Select(a.FirstName, a.LastName, a.ActorId)
                .From(a)
                .Where(a.FirstName, Op.EQ, firstName)
                .Where(a.LastName, Op.EQ, lastName);

            var sql = Database.Compiler.Compile(q).Sql;
            Console.WriteLine(sql);

            return await Database.FirstOrDefaultAsync<Actor>(q);
        }
    }

}