using DbSet.Model;

using var db = new ApplicationContext();
Console.ReadKey();
db.Database.EnsureDeletedAsync();