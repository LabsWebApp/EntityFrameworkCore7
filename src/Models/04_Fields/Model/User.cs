#pragma warning disable CS0649
namespace Fields.Model;

public class User
{
    private readonly int id;
    private readonly string name;
    private readonly int age;
    public int Id => id;
    public int Age => age;
    public User(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Print() => Console.WriteLine($"{id}. {name} - {age}");
}