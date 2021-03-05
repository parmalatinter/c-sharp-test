using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// https://www.npgsql.org/efcore/
/// </summary>
namespace ConsoleAppTest.pg
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=pg");

        public DbSet<model.Movie> Movie { get; set; }
    }
}
