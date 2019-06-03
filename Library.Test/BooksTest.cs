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
        Books b = new MediumBook(AuthorsTest.a, "Natural Language Processing in Action", 300);
        Books b1 = new MediumBook(AuthorsTest.a1, "Grokking Deep Learning", 359);
        Books b2 = new MediumBook(AuthorsTest.a2, "Rootkits And Bootkits", 504);
        Books b3 = new LargeBook(AuthorsTest.a3, "C# 7.0 in a Nutshell", 1056);
        Books b4 = new SmallBook(AuthorsTest.a3, "LINQ Pocket Reference", 172);
        Books b5 = new MediumBook(AuthorsTest.a4, "Clean Code: A Handbook of Agile Software Craftmanship", 464);

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
        public void DeleteBookWithId()
        {
            int id = b2.id;
            Books.DeleteBookFromId(id);
            int i = Books.books.IndexOf(b2);
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

        [TestMethod]
        public void GetBookFromId()
        {
            Books b = Books.GetBookFromId(2);
            Assert.AreEqual(b2, b, "The Books are equal");
        }
    }
}
