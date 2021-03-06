using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ConsoleAppTest.pg.model
{
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
    }
}
