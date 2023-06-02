using System.Runtime.InteropServices.ComTypes;
using Microsoft.IdentityModel.Tokens;
#pragma warning disable CA1822

namespace BulkCrudModel;

public class PersonRepo
{
    public void Insert(int quantity, bool show = false)
    {
        using var context = new BulkCrudContext(show);
        context.People.AddRange(
            Enumerable.Range(1, quantity)
                .Select(i =>
                    new Person
                    {
                        Name = $"Name-{i}",
                        DeleteMe = i % 2 == 0
                    }));

        context.SaveChanges();
    }
    
}