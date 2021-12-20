using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Generated.Domain;
using SchemaTypist.Generated.Persistence.Mapping;
using SchemaTypist.SqlKata;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SchemaTypist.Samples.PostgreSql.Sakila
{
    public class SampleApplication
    {
        public static async Task Main(string[] args)
        {
            DapperTypeMapping.Init();
            SampleRepository sr = new SampleRepository();
            var films = await sr.GetFilmsByReturnDate();
            foreach (var film in films)
            {
                Console.WriteLine($"{film.Title}:  {film.Description}");
            }
        }
    }

    public class SampleRepository
    {
        public async Task<IEnumerable<Film>> GetFilmsByReturnDate()
        {
            /**
             * select f.title, f.description
             * from rental r
             * inner join inventory i on r.inventory_id = i.inventory_id
             * inner join film f on i.film_id = f.film_id
             * where r.return_date < '2005-05-31'
             */

            var r = Public.RentalMapper.Table.As("r");
            var i = Public.InventoryMapper.Table.As("i");
            var f = Public.FilmMapper.Table.As("f");

            var q = new Query()
                .Select(f.Title, f.Description)
                .From(r)
                .Join(i, j => j.On(r.InventoryId, i.InventoryId))
                .Join(f, j => j.On(i.FilmId, f.FilmId))
                .Where(r.ReturnDate, Op.LT, DateTime.Parse("31 May 2005"));

            var connection = new NpgsqlConnection(@"Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=N3v3r!nPr0d;");
            var compiler = new PostgresCompiler();
            var db = new QueryFactory(connection, compiler);
            var posts = await db.GetAsync<Film>(q);
            return posts;

        }
    }
}
