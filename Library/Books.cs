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
        public int p { get; set; }
        public static List<Books> books = new List<Books>();
        public static int nextId = 0;

        public static void ListAllBooks()
        {
            Console.WriteLine();
            foreach (Books b in books)
            {
                WriteBook(b);
            }
        }

        public static void WriteBook(Books b)
        {
            Author a = Author.GetAuthorFromId(b.authorId);
            if (a != null)
            {
                Console.WriteLine("ID: {0}, Author Name: {1} {2}, Book Title: {3}, Pages: {4}, Type: {5}", b.id, a.firstName, a.lastName, b.title, b.p, b.type);
            }
            else
            {
                Console.WriteLine("ID: {0}, Author Name: {1} {2}, Book Title: {3}, Pages: {4}, Type: {5}", b.id, "DELETED", "AUTHOR", b.title, b.p, b.type);
            }
        }

        public static void CreateDataForNewBook()
        {
            Author a = AddAuthorForNewBook();
            string title = AddTitleForNewBook();
            int pages = AddAmountOfPagesForNewBook();
            AddNewBook(a, title, pages);
        }
        public static void AddNewBook(Author a, string t, int p)
        {
            if (p < 250)
            {
                SmallBook b = new SmallBook(a, t, p);
            }
            else if (p > 250 && p < 750)
            {
                MediumBook b = new MediumBook(a, t, p);
            }
            else
            {
                LargeBook b = new LargeBook(a, t, p);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\"{0}\" has been added to your library", t);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static Author AddAuthorForNewBook()
        {
            int authorId = Author.GetAuthorId();
            return Author.GetAuthorFromId(authorId);
        }

        private static string AddTitleForNewBook()
        {
            Console.WriteLine();
            Console.WriteLine("What title does the new book have?");
            return Console.ReadLine();
        }

        private static int AddAmountOfPagesForNewBook()
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} is not a valid number, try again", userInput);
                Console.ForegroundColor = ConsoleColor.Gray;
                AddAmountOfPagesForNewBook();
            }
            return 0;
        }

        public static void DeleteBook()
        {
            int bookId = GetBookId();
            DeleteBookFromId(bookId);
        }

        public static void DeleteBookFromId(int id)
        {
            Books b = GetBookFromId(id);
            string bookTitle = b.title;
            books.Remove(b);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The book \"{0}\" has been removed from your library", bookTitle);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DeleteAllBooks()
        {
            books.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All books from your library has been removed");
            Console.ForegroundColor = ConsoleColor.Gray;
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

        private static int GetBookId()
        {
            ListAllBooks();
            Console.WriteLine("Enter the ID of the book you want for this action:");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                return userInputNumeric;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} is not a valid input, try again", userInput);
                Console.ForegroundColor = ConsoleColor.Gray;
                GetBookId();
            }
            return 0;

        }

        public static void GetIdsToChangeAuthorOnBook()
        {
            int authorId = Author.GetAuthorId();
            int bookId = GetBookId();
            ChangeAuthorOnBook(authorId, bookId);
        }
        public static void ChangeAuthorOnBook(int bookId, int authorId)
        {
            Books b = GetBookFromId(bookId);
            Author oldAuthor = Author.GetAuthorFromId(b.authorId);
            Author newAuthor = Author.GetAuthorFromId(authorId);
            int listIndex = books.IndexOf(b);
            books[listIndex].authorId = authorId;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Author on the book \"{0}\" has been changed from \"{1}\" to \"{2}\"", b.title, oldAuthor.firstName + " " + oldAuthor.lastName, newAuthor.firstName + " " + newAuthor.lastName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
