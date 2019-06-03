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
    }
}
