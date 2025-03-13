using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Data;

public class BowlingDbContext : DbContext
{
    public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
    {
    }
    
    public DbSet<Bowling> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; } 
}