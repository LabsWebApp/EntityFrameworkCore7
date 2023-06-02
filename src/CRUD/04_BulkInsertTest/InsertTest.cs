using BenchmarkDotNet.Attributes;
using BulkCrudModel;
#pragma warning disable CA1822
#pragma warning disable VSSpell001

namespace BulkInsertTest;

[MemoryDiagnoser()]
public class InsertTest
{
    private const int BatchSize = 50_000;

    [Params(10, 100, 10000, 1_000_000)]
    public int N;

    [Benchmark(Description = "EF")]
    public void EfTest()
    {
        new PersonRepo().Insert(N);
        AdoMethods.Truncate();
    }

    [Benchmark(Description = "ADO")]
    public void AdoTest()
    {
        AdoMethods.BulkInsertPeople(
            Enumerable.Range(1, N)
                .Select(i =>
                    new Person()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name" + i.ToString(),
                        DeleteMe = i % 2 == 0
                    }), BatchSize);
        AdoMethods.Truncate();
    }

    [GlobalSetup]
    public void Set()
    {
        using var context = new BulkCrudContext(false);
        context.Database.EnsureCreated();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        using var context = new BulkCrudContext(false);
        context.Database.EnsureDeleted();
    }
}