using DbSet.Model.Entities;
using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;

namespace DbSet.Model;

public sealed class ApplicationContext : DbContext
{
    // Добавляем в ДБ Users + Company
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite(GetConnectionStrings());

    // Добавляем в ДБ Country
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>();
        //modelBuilder.Ignore<Company>(); // не сохранять в БД
        //modelBuilder.Entity<User>().Ignore(u=> u.Company); // не сохранять в БД
    }
}