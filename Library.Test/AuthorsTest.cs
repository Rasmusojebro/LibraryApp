using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test
{
    [TestClass]
    public class AuthorsTest
    {
        public static Author a = new Author("Lane", "Hobson");
        public static Author a1 = new Author("Andrew W", "Trask");
        public static Author a2 = new Author("Alex", "Matroosov");
        public static Author a3 = new Author("Joseph", "Albahari");
        public static Author a4 = new Author("Robert C", "Martin");
        List<Author> authorsTest = Author.authors;

        [TestMethod]
        public void GetAuthorFromIdTest()
        {
            //Arrange
            int ID = 2;
            //Act
            var y = authorsTest.Where(x => x.id == ID).First();
            //Assert
            Assert.AreEqual(a2, y, "The Authors are Equal");
        }
    }
}
