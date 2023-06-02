using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;

namespace Fields.Model;

public sealed class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(GetConnectionStrings());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property("Id").HasField("id");
        modelBuilder.Entity<User>().Property("Age").HasField("age");
        modelBuilder.Entity<User>().Property("name");
    }
}