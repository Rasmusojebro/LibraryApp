using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        public static Author a = new Author("Lane", "Hobson");
        public static Author a1 = new Author("Andrew W", "Trask");
        public static Author a2 = new Author("Alex", "Matroosov");
        public static Author a3 = new Author("Joseph", "Albahari");
        public static Author a4 = new Author("Robert C", "Martin");
        public static List<Author> authors = Author.authors;

        public static Books b = new MediumBook(a, "Natural Language Processing in Action", 300);
        public static Books b1 = new MediumBook(a1, "Grokking Deep Learning", 359);
        public static Books b2 = new MediumBook(a2, "Rootkits And Bootkits", 504);
        public static Books b3 = new LargeBook(a3, "C# 7.0 in a Nutshell", 1056);
        public static Books b4 = new SmallBook(a3, "LINQ Pocket Reference", 172);
        public static Books b5 = new MediumBook(a4, "Clean Code: A Handbook of Agile Software Craftmanship", 464);
        public static List<Books> books = new List<Books>();



        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            authors.Add(a);
            authors.Add(a1);
            authors.Add(a2);
            authors.Add(a3);
            authors.Add(a4);

            books.Add(b);
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);
            books.Add(b4);
            books.Add(b5);
            Books.books = books;


        }
    }
}
