using ConsoleApp.pg.model;
using System.Linq;

namespace ConsoleApp.Migrations
{
    public class Seed 
    {
        public static void Exec(ApplicationDbContext context)
        {
            if (!context.Movie.Any())
            {
                var entity = new Movie() { Id = 1, Name = "TEST" };
                context.Movie.Add(entity);
                context.SaveChanges();
            }
        }
    }
}
