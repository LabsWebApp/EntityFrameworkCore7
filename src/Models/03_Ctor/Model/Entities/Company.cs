using System.ComponentModel.DataAnnotations.Schema;

namespace Ctor.Model.Entities;

// не создастся, тк есть ctor
public class Company : EntityBase
{
    public ICollection<User> Users { get; set; } = new List<User>();
    public Company(string name)
    {
        Name = name;
        Console.WriteLine($"Вызов конструктора для объекта - {name}.");
    }
}