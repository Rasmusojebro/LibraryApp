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
        public void CreateAuthor()
        {
            Author newAuthor = new Author("Rasmus", "Öjebro");
            Author author = Author.Authors.Last();
            Assert.AreEqual(newAuthor, author, "Author skapad korrekt");
        }
        [TestMethod]
        public void GetAuthorFromIdTest()
        {
            //Arrange
            int ID = 2;
            //Act
            var y = SetupAssemblyInitializer.authors.Where(x => x.Id == ID).First();
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
            int startCount = Author.Authors.Count();
            Author.DeleteAllAuthors();
            int endCount = Author.Authors.Count();
            Assert.AreEqual(0, Author.Authors.Count, startCount + " authors has been deleted from your library!");
        }

        [TestMethod]
        public void DeleteAuthorWithAuthor()
        {
            Author.DeleteAuthorWithAuthor(SetupAssemblyInitializer.a2);
            int i = Author.Authors.IndexOf(SetupAssemblyInitializer.a2);
            Assert.AreEqual(-1, i, "The Author has been deleted");
        }

        [TestMethod]
        public void GetAllBooksFromSpecificAuthor()
        {
            int authorTestId = 2;
            List<Book> books = Author.GetAllBooksFromSpecificAuthor(authorTestId);

            bool allHasSameId = true;
            foreach (Book book in books)
            {
                if (book.AuthorId != authorTestId)
                {
                    allHasSameId = false;
                }
            }
            Assert.IsTrue(allHasSameId, "All books has same authorId");
        }
    }
}
