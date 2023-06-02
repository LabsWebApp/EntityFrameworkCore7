using CodeFirst.Entities;
using AppContext = CodeFirst.AppContext;

using var db1 = new AppContext();

// пере-создаём DB (public AppContext() => Database.EnsureCreated();) 
//db.Database.EnsureDeleted();
db1.Database.EnsureCreated();

using var db = new AppContext();
static void ShowData(IEnumerable<User> users)
{
    Console.WriteLine("Список объектов:");
    foreach (var u in users) Console.WriteLine($"[{u.Id.ToString().ToUpper()}].{u.Name} - {u.Age}");
}

ShowData(db.Users);

// создаем два объекта User
var v = new User { Name = "Vasja", Age = 33 };
var m = new User { Name = "Masha", Age = 26 };
var k = new User { Name = "Kolja", Age = -1 };

// добавляем их в бд
db.Users.Add(v);
db.Users.Add(m);
db.Users.Add(k);
db.Users.FirstOrDefault(u => u.Name == "new")!.Age = 99;
var result = db.SaveChanges();
Console.WriteLine(result > 0 ? $"Объекты успешно сохранены ({result})" : "Что-то пошло не так(((");

// получаем объекты из бд и выводим на консоль
ShowData(db.Users);

Console.Read();