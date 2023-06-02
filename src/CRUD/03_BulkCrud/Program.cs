using BulkCrudModel;
using Microsoft.EntityFrameworkCore;
using static BulkCrudModel.BulkCrudContext;
using static BulkCrudModel.AdoMethods;

using var context = new BulkCrudContext();
var repo = new PersonRepo();
var quantity = 1_000_000;

context.Database.EnsureCreated();

Console.WriteLine("\nДобавление...");
repo.Insert(quantity);
//Console.Clear();
Console.WriteLine("Добавление закончилось\n");

Console.WriteLine("Удаление...");
context.People.Where(p => p.DeleteMe).ExecuteDelete();
Console.WriteLine("Удаление закончилось\n");

Console.WriteLine("Обновление...");
var now = DateTime.UtcNow;
context.People.ExecuteUpdate(s =>
    s.SetProperty(p => p.UpdateTime, p => now)
        .SetProperty(p => p.Name, p => p.Name + " [UPDATED]"));
Console.WriteLine("Обновление закончилось\n");

Console.ReadKey();

context.Database.EnsureDeleted();