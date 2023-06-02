using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;

namespace CodeFirst;

public sealed class AppContext : DbContext
{
    private readonly string Cs = GetConnectionStrings();

    public DbSet<User> Users => Set<User>(); // = null!;
    
    public AppContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(Cs);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = new Guid("F804A5D5-CBCF-4569-8EB4-DD97F207DDEA"),
            Name = "new",
            Age = 0
        });
    }
}