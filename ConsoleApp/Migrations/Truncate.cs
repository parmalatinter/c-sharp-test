using ConsoleApp.pg.model;
using System.Linq;

namespace ConsoleApp.Migrations
{
    public class Truncate
    {
        public static void Exec(ApplicationDbContext context)
        {
            if (context.Movie.Any())
            {
                context.Movie.RemoveRange(context.Movie);
                context.SaveChanges();
            }
        }
    }
}
