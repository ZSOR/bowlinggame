using BowlingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BowlingGame.DAL
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }
    
        public DbSet<GameDTO>? Games { get; set; }
        public DbSet<PlayerDTO>? Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerDTO>().HasOne(p => p.Game).WithMany(g => g.Players);

        }
    }
}
