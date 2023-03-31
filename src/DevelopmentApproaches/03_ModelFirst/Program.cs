using ModelFirst.Models;
using ModelFirst.Models.Entities;

using var db = new DataContext();

// пере-создаём DB (public AppContext() => Database.EnsureCreated();) 
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// создаем два объекта User
var vasja = new User("Vasja", 33 );
var masha = new User("Masha", 2);

// добавляем их в бд
db.Users.Add(new User());
db.Users.Add(vasja);
db.Users.Add(masha);
db.SaveChanges();
WriteLine("Объекты успешно сохранены");

// получаем объекты из бд и выводим на консоль
var users = db.Users.ToList(); //? 
WriteLine("Список объектов:");
foreach (var u in users) Console.WriteLine($"[{u.Id.ToString().ToUpper()}].{u.Name} - {u.Age}");

Read();
