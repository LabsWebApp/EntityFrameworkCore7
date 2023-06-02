using Ctor.Model;
using Ctor.Model.Entities;

using (ApplicationContext db = new())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var tom = new User("Tom", 37) { Company = new("KZ") };
    var bob = new User("Bob", 41);
    db.Users.Add(tom);
    db.Users.Add(bob);
    db.SaveChanges();
}

using (ApplicationContext db = new())
{
    
    Console.WriteLine("Получение данных из БД");
    var users = db.Users.ToList();
    foreach (var user in users)
        Console.WriteLine($"{user.Name} - {user.Age} - {user.Company?.Name ?? "no data"}");
    Console.ReadKey();
    db.Database.EnsureDeleted();
}