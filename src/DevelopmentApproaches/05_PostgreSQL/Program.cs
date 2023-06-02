using PostgreSQLCodeFirst.Model;
using AppContext = PostgreSQLCodeFirst.Model.AppContext;

// добавление данных
using (var db = new AppContext())
{
    // создаем два объекта User
    User user1 = new() { Name = "Tom", Age = 33 };
    User user2 = new() { Name = "Alice", Age = 26 };

    // добавляем их в бд
    db.Users.AddRange(user1, user2);
    db.SaveChanges();
}

// получение данных
using (var db = new AppContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Users list:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

    Console.ReadKey();
    db.Database.EnsureDeleted();
}
Console.ReadKey();