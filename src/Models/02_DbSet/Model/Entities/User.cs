using System.ComponentModel.DataAnnotations.Schema;

namespace DbSet.Model.Entities;

public class User : EntityBase
{
    public int Age { get; set; }

    // навигационное свойство
    //[NotMapped] // не сохранять в БД
    public Company? Company { get; set; }
}