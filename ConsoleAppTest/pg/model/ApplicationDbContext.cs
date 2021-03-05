using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;

/// <summary>
/// https://www.npgsql.org/efcore/
/// </summary>
namespace ConsoleAppTest.pg
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            string ConnectionString = section.ConnectionStrings[1].ConnectionString;
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<model.Movie> Movie { get; set; }
    }
}
