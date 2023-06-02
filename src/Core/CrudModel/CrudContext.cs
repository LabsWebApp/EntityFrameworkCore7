using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;

namespace CrudModel;

public sealed class CrudContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public CrudContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder
            .UseSqlite(GetConnectionStrings())
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
}