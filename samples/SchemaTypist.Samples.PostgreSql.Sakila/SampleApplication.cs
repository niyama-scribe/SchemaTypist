using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

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

            var actorRepository = new ActorRepository(fr.Connection);
            var actors = await actorRepository.FindActorsByLastNameContaining("li");
            foreach (var actor in actors)
            {
                Console.WriteLine($"Actor: {actor.FirstName} {actor.LastName}");
            }

            var actorLastNameStats = await actorRepository.GetActorSharedLastNameStats();
            foreach (dynamic actorLastNameStat in actorLastNameStats)
            {
                Console.WriteLine($"Last Name Trivia: There are {actorLastNameStat.actor_count} actors with the last name {actorLastNameStat.last_name}");
            }

        }
    }
}
