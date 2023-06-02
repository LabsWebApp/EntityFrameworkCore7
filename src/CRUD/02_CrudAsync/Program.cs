using CrudModel;
using Microsoft.EntityFrameworkCore;

// Добавление
await using (var db = new CrudContext())
{
    Console.WriteLine("Добавление:");
    var tom = new User { Name = "Tom", Age = 33 };
    var alice = new User { Name = "Alice", Age = 26 };
    var v = new User { Name = "Vasja", Age = 18 };
    var m = new User { Name = "Masha", Age = 21 };
    var k = new User { Name = "Kolja", Age = 20 };

    // Добавление
    await db.Users.AddRangeAsync(tom, alice, v, m, k);
    await db.SaveChangesAsync();
}
Console.WriteLine("*****\n");

// получение
await using (var db = new CrudContext())
{
    Console.WriteLine("Получение:");
    // получаем объекты из бд и выводим на консоль
    var users = await db.Users.ToListAsync();
    Console.WriteLine("Данные после добавления:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}
Console.WriteLine("*****\n");

// Редактирование
await using (var db = new CrudContext())
{
    Console.WriteLine("Редактирование:");
    // получаем первый объект
    var user = await db.Users.FirstOrDefaultAsync();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        //обновляем объект
        await db.SaveChangesAsync();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    var users = await db.Users.ToListAsync();
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
}
Console.WriteLine("*****\n");

// Удаление
await using (var db = new CrudContext())
{
    Console.WriteLine("Удаление:");
    // получаем первый объект
    var user = await db.Users.FirstOrDefaultAsync();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        await db.SaveChangesAsync();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    var users = await db.Users.ToListAsync();
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

    await db.Database.EnsureDeletedAsync();
}

Console.ReadKey();