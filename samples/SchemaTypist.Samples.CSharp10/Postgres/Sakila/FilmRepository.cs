using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.DatabaseMetadata;
using SchemaTypist.Samples.CSharp10.Postgres.Sakila.Generated.Domain.Public;
using SchemaTypist.Samples.CSharp10.Postgres.Sakila.Generated.Persistence.Public;
using SchemaTypist.SqlKata;
using SqlKata;

namespace SchemaTypist.Samples.CSharp10.Postgres.Sakila
{
    public class FilmRepository : SakilaRepository
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
                .AsUpdate(new[] { f.RentalRate }, new object[] { film.RentalRate })
                .Where(f.FilmId, Op.EQ, film.FilmId);

            var _ = await Database.ExecuteAsync(q);
        }
    }
}
