using System.ComponentModel.DataAnnotations.Schema;

namespace FluentApiAndDataAnnotations.Model;


// DataAnnotations
[Table("People")]
public class User
{
    [Column("user_id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public int Age { get; set; }
}