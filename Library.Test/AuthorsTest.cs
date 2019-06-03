using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test
{
    [TestClass]
    public class AuthorsTest
    {
 

        [TestMethod]
        public void GetAuthorFromIdTest()
        {
            //Arrange
            int ID = 2;
            //Act
            var y = SetupAssemblyInitializer.authors.Where(x => x.id == ID).First();
            //Assert
            Assert.AreEqual(SetupAssemblyInitializer.a2, y, "The Authors are Equal");
        }

        [TestMethod]
        public void GetAuthorFromId()
        {
            Author a = Author.GetAuthorFromId(2);
            Assert.AreEqual(SetupAssemblyInitializer.a2, a, "The authors are equal");
        }

        [TestMethod]
        public void DeleteAllAuthors()
        {
            int startCount = Author.authors.Count();
            Author.DeleteAllAuthors();
            int endCount = Author.authors.Count();
            Assert.AreEqual(0, Author.authors.Count, startCount + " authors has been deleted from your library!");
        }

        [TestMethod]
        public void DeleteAuthorWithAuthor()
        {
            Author.DeleteAuthorWithAuthor(SetupAssemblyInitializer.a2);
            int i = Author.authors.IndexOf(SetupAssemblyInitializer.a2);
            Assert.AreEqual(-1, i, "The Author has been deleted");
        }
    }
}
