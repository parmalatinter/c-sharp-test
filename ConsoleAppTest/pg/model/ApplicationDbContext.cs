using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ConsoleAppTest.pg.model
{
    /// <summary>
    /// https://www.npgsql.org/efcore/
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            string ConnectionString = section.ConnectionStrings[0].ConnectionString;
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        Id = 1,
                        Name = "TEST"
                    },
                    new Movie
                    {
                        Id = 2,
                        Name = "TEST2",
                    }
                );
        }
    }
}
