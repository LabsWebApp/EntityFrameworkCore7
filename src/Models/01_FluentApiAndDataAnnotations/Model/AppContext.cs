using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static ConnectionStrings.ConnectionStrings;

namespace FluentApiAndDataAnnotations.Model;

// Fluent Api
public sealed class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseSqlite(GetConnectionStrings())
        .LogTo(Console.WriteLine, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // использование Fluent API
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<User>().ToTable("People", schema: "userstore"); // schema is not supported
        modelBuilder
            .Entity<User>()
            .Property(u => u.Age)
            .HasColumnName("age");
    }
}