using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BowlingGame.DAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BowlingDbContext>
    {
        public BowlingDbContext CreateDbContext(string[] args)
        {
            //TODO: Move connectionstring to config
            return new BowlingDbContext(new DbContextOptionsBuilder<BowlingDbContext>()
                .UseMySql(ConfigurationService.Configuration.GetConnectionString("MigrationConnection"), new MySqlServerVersion("8.0.22"))
                .Options);
        }
    }
}
