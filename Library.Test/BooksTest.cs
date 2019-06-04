using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test
{
    [TestClass]
    public class BooksTest
    {
        [TestMethod]
        public void CreateSmallBook()
        {
            Author a = new Author("Rasmus", "Öjebro");
            string title = "Rasmus Test Bok";
            int pages = 249;
            Book.AddNewBook(a, title, pages);
            Book b = Book.Books.Last();
            Assert.AreEqual("small", b.Type, "New small book has type: {0}", b.Type);
        }
        [TestMethod]
        public void CreateMediumBook()
        {
            Author a = new Author("Rasmus", "Öjebro");
            string title = "Rasmus Test Bok";
            int pages = 584;
            Book.AddNewBook(a, title, pages);
            Book b = Book.Books.Last();
            Assert.AreEqual("medium", b.Type, "New medium book has type: {0}", b.Type);
        }
        [TestMethod]
        public void CreateLargeBook()
        {
            Author a = new Author("Rasmus", "Öjebro");
            string title = "Rasmus Test Bok";
            int pages = 10000;
            Book.AddNewBook(a, title, pages);
            Book b = Book.Books.Last();
            Assert.AreEqual("large", b.Type, "New large book has type: {0}", b.Type);
        }


        [TestMethod]
        public void GetBookFromId()
        {
            Book b = Book.GetBookFromId(2);
            Assert.AreEqual(2, b.Id, "The Books are equal");
        }

        [TestMethod]
        public void ChangeAuthorOnBook()
        {
            Book b = Book.GetBookFromId(1);
            int currentId = b.AuthorId;
            Book.ChangeAuthorOnBook(1, 4);
            Assert.AreEqual(4, b.AuthorId, "The Author Has Been Changed On This Book: " + currentId);
        }

        [TestMethod]
        public void DeleteBookWithId()
        {
            int id = SetupAssemblyInitializer.b2.Id;
            Book.DeleteBookFromId(id);
            int i = Book.Books.IndexOf(SetupAssemblyInitializer.b2);
            Assert.AreEqual(-1, i, "The book has been deleted");
        }

        [TestMethod]
        public void DeleteAllBooks()
        {
            int startCount = Book.Books.Count();
            Book.DeleteAllBooks();
            int endCount = Book.Books.Count();
            Assert.AreEqual(0, Book.Books.Count, startCount + " books has been deleted from your library!");
        }
    }
}
