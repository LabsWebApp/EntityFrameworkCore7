using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CodeFirst.Entities;

namespace CodeFirst.Tests
{
    [TestClass()]
    public class AppContextTests
    {
        [TestMethod()]
        public void AppContextTest_CreateDb()
        {
            //Arrange
            var context = new AppContext();

            //Act
            context.Dispose();

            //Assert
            Assert.IsTrue(File.Exists(@"C:\Data\Ef7\data.db"));
        }

        [TestMethod()]
        public void AppContextTest_UpdateUsers()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            User exp = new User() { Id = id, Age = 10, Name = "Petja" };
            User? act = null;

            //Act
            using (var context = new AppContext())
            {
                context.Users.Add(exp);
                context.SaveChanges();
            }

            using (var context = new AppContext())
            {
                act = context.Users.FirstOrDefault(u => u.Id == id);
            }

            //Assert
            Assert.AreEqual(exp.Name, act?.Name);
            Assert.AreEqual(exp.Age, act?.Age);
        }
    }
}