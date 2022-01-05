using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Generated.Domain;
using SchemaTypist.Generated.Persistence.Mapping;
using SchemaTypist.SqlKata;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using static SchemaTypist.Generated.Persistence.Mapping.Public;

namespace SchemaTypist.Samples.PostgreSql.Sakila
{
    public class SampleApplication
    {
        public static async Task Main(string[] args)
        {
            var fr = new FilmRepository("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=N3v3r!nPr0d;");

            var films = await fr.GetRentedFilmsByReturnDate(DateTime.Parse("31 May 2005"));
            foreach (var film in films)
            {
                Console.WriteLine($"{film.Title}:  {film.Description}");
            }

            var autumnCrow = await fr.GetFilmByTitle("AUTUMN CROW");
            if (autumnCrow != null)
            {
                Console.WriteLine($"{autumnCrow.Title} : {autumnCrow.Description} : {autumnCrow.RentalRate}");
                //Update rating
                autumnCrow.RentalRate = decimal.Equals(autumnCrow.RentalRate, new decimal(4.99)) ? new decimal(2.99) : new decimal(4.99);
                await fr.UpdateFilmRentalRate(autumnCrow);

                var refetch = await fr.GetFilmByTitle("AUTUMN CROW");
                Console.WriteLine($"After update - {refetch.Title} : {refetch.Description} : {refetch.RentalRate}");
            }
        }
    }

    internal class FilmRepository : BaseRepository
    {
        public FilmRepository(string connectionString, int timeout = 30) : base(connectionString, timeout)
        {
        }
        public FilmRepository(IDbConnection dbConnection, int timeout = 30) : base(dbConnection, timeout)
        {
        }

        public async Task<IEnumerable<Film>> GetRentedFilmsByReturnDate(DateTime asOfDate)
        {
            /**
             * select f.title, f.description
             * from rental r
             * inner join inventory i on r.inventory_id = i.inventory_id
             * inner join film f on i.film_id = f.film_id
             * where r.return_date < '2005-05-31'
             */

            var r = RentalDao.Table.As("r");
            var i = InventoryDao.Table.As("i");
            var f = FilmDao.Table.As("f");

            var q = new Query()
                .Select(f.Title, f.Description)
                .From(r)
                .Join(i, j => j.On(r.InventoryId, i.InventoryId))
                .Join(f, j => j.On(i.FilmId, f.FilmId))
                .Where(r.ReturnDate, Op.LT, asOfDate);

            var posts = await Database.GetAsync<Film>(q);
            return posts;

        }

        public async Task<Film> GetFilmByTitle(string title)
        {
            var f = FilmDao.Table.As("f");

            var query = new Query()
                .Select()
                .From(f)
                .Where(f.Title, Op.EQ, title);

            var film = await Database.FirstOrDefaultAsync<Film>(query);
            return film;
        }

        public async Task UpdateFilmRentalRate(Film film)
        {
            var f = FilmDao.Table;

            var q = new Query("film")
                .AsUpdate(new [] {f.RentalRate}, new object[] {film.RentalRate} )
                .Where(f.FilmId, Op.EQ, film.FilmId);

            var _ = await Database.ExecuteAsync(q);
        }

        
    }

    public abstract class BaseRepository
    {
        static BaseRepository()
        {
            DapperTypeMapping.Init();
        }
        private static readonly RepositoryConnector RepositoryType = RepositoryConnector.PostgreSql;
        protected QueryFactory Database { get; }

        protected BaseRepository(string connectionString, int timeout=30) => Database = RepositoryType.UseConnectionString(connectionString, timeout);
        protected BaseRepository(IDbConnection dbConnection, int timeout=30) => Database = RepositoryType.UseDbConnection(dbConnection, timeout);

    }

    public class RepositoryConnector
    {
        internal static RepositoryConnector PostgreSql = new RepositoryConnector( 
            (str, timeout) => new QueryFactory(new NpgsqlConnection(str), new PostgresCompiler(), timeout),
            (dbConnection, timeout) => new QueryFactory(dbConnection, new PostgresCompiler(), timeout));

        public Func<string, int, QueryFactory> UseConnectionString { get; }
        public Func<IDbConnection, int, QueryFactory> UseDbConnection { get; }

        private RepositoryConnector(Func<string, int, QueryFactory> useConnectionString,
            Func<IDbConnection, int, QueryFactory> useDbConnection)
        {
            UseConnectionString = useConnectionString;
            UseDbConnection = useDbConnection;
        }


    }
}
