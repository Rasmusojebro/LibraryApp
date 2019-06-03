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
            Books.AddNewBook(a, title, pages);
            Books b = Books.books.Last();
            Assert.AreEqual("small", b.type, "New small book has type: {0}", b.type);
        }
        [TestMethod]
        public void CreateMediumBook()
        {
            Author a = new Author("Rasmus", "Öjebro");
            string title = "Rasmus Test Bok";
            int pages = 584;
            Books.AddNewBook(a, title, pages);
            Books b = Books.books.Last();
            Assert.AreEqual("medium", b.type, "New medium book has type: {0}", b.type);
        }
        [TestMethod]
        public void CreateLargeBook()
        {
            Author a = new Author("Rasmus", "Öjebro");
            string title = "Rasmus Test Bok";
            int pages = 10000;
            Books.AddNewBook(a, title, pages);
            Books b = Books.books.Last();
            Assert.AreEqual("large", b.type, "New large book has type: {0}", b.type);
        }


        [TestMethod]
        public void GetBookFromId()
        {
            Books b = Books.GetBookFromId(2);
            Assert.AreEqual(2, b.id, "The Books are equal");
        }

        [TestMethod]
        public void ChangeAuthorOnBook()
        {
            Books b = Books.GetBookFromId(1);
            int currentId = b.authorId;
            Books.ChangeAuthorOnBook(1, 4);
            Assert.AreEqual(4, b.authorId, "The Author Has Been Changed On This Book: " + currentId);
        }

        [TestMethod]
        public void DeleteBookWithId()
        {
            int id = SetupAssemblyInitializer.b2.id;
            Books.DeleteBookFromId(id);
            int i = Books.books.IndexOf(SetupAssemblyInitializer.b2);
            Assert.AreEqual(-1, i, "The book has been deleted");
        }

        [TestMethod]
        public void DeleteAllBooks()
        {
            int startCount = Books.books.Count();
            Books.DeleteAllBooks();
            int endCount = Books.books.Count();
            Assert.AreEqual(0, Books.books.Count, startCount + " books has been deleted from your library!");
        }
    }
}
