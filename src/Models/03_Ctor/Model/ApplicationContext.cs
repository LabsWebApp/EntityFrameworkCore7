using Ctor.Model.Entities;
using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;

namespace Ctor.Model;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(GetConnectionStrings());
}