using Fields.Model;

using var db = new ApplicationContext();

var bob = new User("Bob", 30);
var kate = new User("Kate", 29);
db.Users.Add(bob);
db.Users.Add(kate);
db.SaveChanges();

var users = db.Users.ToList();
foreach (var user in users) user.Print();

Console.ReadKey();
db.Database.EnsureDeleted();