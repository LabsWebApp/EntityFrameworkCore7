using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Tests
{
    [TestClass()]
    public class AppContextTests
    {
        [TestMethod()]
        public void AppContextTest_DbEnsureCreated()
        {
            //Arrange
            using var context = new AppContext();

            //Assert
            Assert.IsTrue(File.Exists("C:\\Data\\Ef7\\data.db"));
        }

        [TestMethod()]
        public void AddUserTest_NewUserExists()
        {
            //Arrange
            User user = new User() { Age = 10, Id = new Guid(), Name = "Petja" };
            using (var write = new AppContext())
            {
                //Act
                write.Users.Add(user);
                write.SaveChanges();
            }

            //Assert
            using var read = new AppContext();
            Assert.IsInstanceOfType(
                read.Users.FirstOrDefault(u => u.Id == user.Id), typeof(User));
        }
    }
}