using Backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace Backend.Database;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Challenge> Challenges { get; set; }
    
    public DbSet<Submission> Submissions { get; set; }
    
    public DbSet<Follows> Follows { get; set; }
    
    public DbSet<Rule> Rules { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=challenger.db");
    }
}