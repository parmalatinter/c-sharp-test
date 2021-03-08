using ConsoleAppTest.pg.model;
using System.Linq;

namespace ConsoleAppTest.Migrations
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
