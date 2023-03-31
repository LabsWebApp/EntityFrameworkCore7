namespace CodeFirst.Entities;

public class User
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public int Age { get; set; }
}