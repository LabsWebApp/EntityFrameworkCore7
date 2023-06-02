using CrudModel;

Console.WriteLine("Добавление:");
using (var db = new CrudContext())
{
    var tom = new User { Name = "Tom", Age = 33 };
    var alice = new User { Name = "Alice", Age = 26 };
    var v = new User { Name = "Vasja", Age = 11 };

    // Добавление
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.Users.Add(v);

    //db.AddRange(Enumerable.Range(1, 3)
    //    .Select(i => new User() { Id = i, Age = i + 10, Name = "Name" + i }));

    db.SaveChanges();
}

Console.WriteLine("*****\n");

Console.ReadLine();

Console.WriteLine("Получение:");
using (var db = new CrudContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Изначальные данные:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}

Console.WriteLine("*****\n");

Console.WriteLine("Редактирование:");
using (var db = new CrudContext())
{
    // получаем первый объект
    var user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        //обновляем объект
        //db.Users.Update(user);
    }
    db.SaveChanges();
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Users.ToList();
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}

Console.WriteLine("Редактирование (update):");

User? userUpdate;

using (var db = new CrudContext())
{
    userUpdate = db.Users.FirstOrDefault();
    var users = db.Users.ToList();
    Console.WriteLine("Данные до редактирования:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}

using (var db = new CrudContext())
{
    if (userUpdate != null)
    {
        userUpdate.Name = "Karl";
        userUpdate.Age = 66;
        //обновляем объект
        db.Users.Update(userUpdate);
    }
    db.SaveChanges();
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = db.Users.ToList();
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}

Console.WriteLine("*****\n");

Console.WriteLine("Удаление:");
using (var db = new CrudContext())
{
    // получаем первый объект
    var user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    var users = db.Users.ToList();
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

    db.Database.EnsureDeleted();
}

Console.WriteLine("*****\n");

Console.ReadKey();