using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static ConnectionStrings.ConnectionStrings;

namespace PostgreSQLCodeFirst.Model;

public sealed class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql(GetConnectionStrings(PostgreSql))
        .LogTo(Console.WriteLine, LogLevel.Information);
}