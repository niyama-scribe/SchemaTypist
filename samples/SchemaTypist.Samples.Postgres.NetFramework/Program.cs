using System;
using System.Threading.Tasks;
using SchemaTypist.Samples.Postgres.NetFramework.Postgres.Sakila.Generated.Domain.Public;

namespace SchemaTypist.Samples.Postgres.NetFramework
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");
            var fr = new FilmRepository("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=N3v3r1nPr0d;");


            var returnDate = new DateTime(2005, 05, 31, 0, 0, 0, DateTimeKind.Utc);
            var films = await fr.GetRentedFilmsByReturnDate(returnDate);
            foreach (var film in films) Console.WriteLine($"{film.Title}:  {film.Description}");

            var autumnCrow = await fr.GetFilmByTitle("AUTUMN CROW");
            if (autumnCrow != null)
            {
                Console.WriteLine($"{autumnCrow.Title} : {autumnCrow.Description} : {autumnCrow.RentalRate}");
                //Update rating
                var filmWithUpdate = autumnCrow;
                filmWithUpdate.RentalRate = decimal.Equals(autumnCrow.RentalRate, new decimal(4.99)) ? new decimal(2.99) : new decimal(4.99);
                await fr.UpdateFilmRentalRate(filmWithUpdate);

                var refetch = await fr.GetFilmByTitle("AUTUMN CROW");
                Console.WriteLine($"After update - {refetch.Title} : {refetch.Description} : {refetch.RentalRate}");
            }

            var actorRepository = new ActorRepository(fr.Connection);
            var actors = await actorRepository.FindActorsByLastNameContaining("li");
            foreach (var actor in actors) Console.WriteLine($"Actor: {actor.FirstName} {actor.LastName}");

            var actorLastNameStats = await actorRepository.GetActorSharedLastNameStats();
            foreach (var actorLastNameStat in actorLastNameStats)
                Console.WriteLine(
                    $"Last Name Trivia: There are {actorLastNameStat.actor_count} actors with the last name {actorLastNameStat.last_name}");

            var rowsAffected = await actorRepository.InsertActor(new Actor {FirstName = "Shabana", LastName = "Azmi"});
            if (rowsAffected > 0)
            {
                var actor = await actorRepository.GetByName("Shabana", "Azmi");
                Console.WriteLine($"Shabana Azmi's actor id is: {actor.ActorId}");
                var rowsDeleted = await actorRepository.DeleteActor(actor.ActorId);
            }
        }
    }
}