using BowlingGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.DAL
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }
    
        public DbSet<GameDTO>? Games { get; set; }
        public DbSet<PlayerDTO>? Players { get; set; }
        public DbSet<ScoreCardDTO> ScoreCards { get; set; }
        public DbSet<FrameDTO> Frames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerDTO>().HasOne(p => p.Game).WithMany(g => g.Players).HasForeignKey(p => p.GameId);
            modelBuilder.Entity<FrameDTO>().HasOne(f => f.ScoreCard).WithMany(s => s.Frames).HasForeignKey(f => f.ScoreCardId);
            modelBuilder.Entity<ScoreCardDTO>().HasOne(s => s.Player).WithOne(p => p.ScoreCard);

        }
    }
}
