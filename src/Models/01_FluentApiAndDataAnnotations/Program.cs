/*
 * Модель в Entity Framework представляет набор всех сущностей и связей между ними,
 * которыми управляет контекст данных. Все сущности, с которыми работает Entity Framework Core
 * и которые хранятся в базе данных, определяются в C# в виде классов.
 * При этом Entity Framework применяет ряд условностей для сопоставления классов с таблицами.
 * Например, названия столбцов должны соответствовать названиям свойств и т.д.
 */

using FluentApiAndDataAnnotations.Model;
using AppContext = FluentApiAndDataAnnotations.Model.AppContext;

using (AppContext db = new())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // создаем два объекта User
    User user1 = new() { Name = "Tom", Age = 33 };
    User user2 = new() { Name = "Alice", Age = 26 };

    // добавляем их в бд
    db.Users.AddRange(user1, user2);
    Console.WriteLine("******** " + db.SaveChanges());
    ;
}

// получение данных
using (var db = new AppContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("People:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

    Console.ReadKey();
    db.Database.EnsureDeleted();
}
Console.ReadKey();