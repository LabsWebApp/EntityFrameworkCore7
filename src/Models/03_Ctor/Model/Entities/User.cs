using System.ComponentModel.DataAnnotations.Schema;

namespace Ctor.Model.Entities;

public class User : EntityBase
{
    public int Age { get; set; }

    // навигационное свойство
    public Company? Company { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine($"Вызов конструктора для объекта - {name} c параметрами - {name}, {age}.");
    }

    public User(string name)
    {
        Name = name;
        Age = 18;
        Console.WriteLine($"Вызов конструктора для объекта - {name}.");
    }
}