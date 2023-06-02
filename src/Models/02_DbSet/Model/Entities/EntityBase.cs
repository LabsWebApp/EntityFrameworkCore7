namespace DbSet.Model.Entities;

public abstract class EntityBase
{
    public int Id { get; init; }
    public string? Name { get; set; }
}