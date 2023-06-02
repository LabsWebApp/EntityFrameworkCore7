namespace BulkCrudModel;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool DeleteMe { get; set; }
    public DateTime UpdateTime { get; set; }
}