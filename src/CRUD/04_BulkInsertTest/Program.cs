using BenchmarkDotNet.Running;
using BulkCrudModel;
using BulkInsertTest;

{
    using var context = new BulkCrudContext(false);
    context.Database.EnsureDeleted();
}

Console.ReadKey();
//BenchmarkRunner.Run<InsertTest>();

{
    using var context = new BulkCrudContext(false);
    context.Database.EnsureCreated();

    AdoMethods.BulkInsertPeople(
        Enumerable.Range(1, 120_000)
            .Select(i =>
                new Person()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name" + i.ToString(),
                    DeleteMe = i % 2 == 0
                }), 50_000);
}


Console.ReadKey();

//context.Database.EnsureDeleted();