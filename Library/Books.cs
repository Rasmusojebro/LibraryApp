using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Books
    {
        public int id { get; set; }
        public string type { get; set; }
        //public Author author { get; set; }
        public int authorId { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public static List<Books> books = new List<Books>();
        public static int nextId = 0;


        public static void ListAllBooks()
        {
            foreach (Books b in books)
            {
                Author a = Author.GetAuthorFromId(b.authorId);
                if (a != null)
                {
                    Console.WriteLine(b.id + ": " + a.firstName + " " + a.lastName + " - " + b.title + ", " + b.pages + ". Type: " + b.type);
                }
                else
                {
                    Console.WriteLine(b.id + ": " + "DELETED" + " " + "AUTHOR" + " - " + b.title + ", " + b.pages + ". Type: " + b.type);
                }

            }
        }
        public static void AddNewBook()
        {
            Author a = GetAuthorForNewBook();
            string title = GetTitleForNewBook();
            int pages = GetAmountPagesForNewBook();
            if (pages < 150)
            {
                SmallBook b = new SmallBook(a, title, pages);
            }
            else if(pages > 150 && pages < 500)
            {
                MediumBook b = new MediumBook(a, title, pages);
            }
            else
            {
                LargeBook b = new LargeBook(a, title, pages);
            }
            Console.WriteLine("{0} has been added to your library", title);
        }

        private static Author GetAuthorForNewBook()
        {
            Author.ListAllAuthors();
            Console.WriteLine();
            Console.WriteLine("Enter AuthorID for the new book:");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                return Author.GetAuthorFromId(userInputNumeric);
            }
            else
            {
                Console.WriteLine("{0} is not a valid id, try again", userInput);
                GetAuthorForNewBook();
            }
            return null;
        }
        private static string GetTitleForNewBook()
        {
            Console.WriteLine();
            Console.WriteLine("What title does the new book have?");
            return Console.ReadLine();
        }
        private static int GetAmountPagesForNewBook()
        {
            Console.WriteLine();
            Console.WriteLine("How many pages does the new book have?");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                return userInputNumeric;
            }
            else
            {
                Console.WriteLine("{0} is not a valid number, try again", userInput);
                GetAmountPagesForNewBook();
            }
            return 0;
        }
        public static void DeleteBook()
        {
            ListAllBooks();
            Console.WriteLine("Enter the ID of the book you want to delete:");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                DeleteBookFromId(userInputNumeric);
            }
            else
            {
                Console.WriteLine("{0} is not a valid input, try again", userInput);
                DeleteBook();
            }
        }
        public static void DeleteBookFromId(int id)
        {
            Books b = GetBookFromId(id);
            books.Remove(b);
        }

        public static Books GetBookFromId(int id)
        {
            try
            {
                return books.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void DeleteAllBooks()
        {
            books.Clear();
        }

    }
}
