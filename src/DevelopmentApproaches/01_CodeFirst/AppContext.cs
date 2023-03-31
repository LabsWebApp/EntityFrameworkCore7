using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst;

public class AppContext : DbContext
{
    public DbSet<User> Users => Set<User>(); // = null!;
    
   // public AppContext() => Database.EnsureCreated();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(
            @"Data Source=C:\Data\Ef7\data.db");

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