using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;
#pragma warning disable CA1050

// Add-Migration InitialCreate
// Update-Database

using var context = new AppContext();

context.Database.Migrate();

Console.Read();

//namespace Migration;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public AppContext()
    {
        //    Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(GetConnectionStrings());
}