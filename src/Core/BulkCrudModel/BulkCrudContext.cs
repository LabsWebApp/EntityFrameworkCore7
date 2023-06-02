using Microsoft.EntityFrameworkCore;
using static ConnectionStrings.ConnectionStrings;
using static BulkCrudModel.AdoMethods;

namespace BulkCrudModel;

public class BulkCrudContext : DbContext
{
    public DbSet<Person> People { get; set; } = null!;

    private readonly bool _show;

    public BulkCrudContext(bool show = true) : base() => _show = show;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionStrings(SqlExpress));
        if (_show) optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
}