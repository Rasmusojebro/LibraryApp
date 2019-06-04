using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public int Id { get; set; }
        public string Type { get; set; }
        //public Author author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public static List<Book> Books = new List<Book>();
        public static int NextId = 0;

        public static void ListAllBooks()
        {
            Console.WriteLine();
            foreach (Book b in Books)
            {
                WriteBook(b);
            }
        }

        public static void WriteBook(Book b)
        {
            Author a = Author.GetAuthorFromId(b.AuthorId);
            if (a != null)
            {
                Console.WriteLine("ID: {0}, Author Name: {1} {2}, Book Title: {3}, Pages: {4}, Type: {5}", b.Id, a.FirstName, a.LastName, b.Title, b.Pages, b.Type);
            }
            else
            {
                Console.WriteLine("ID: {0}, Author Name: {1} {2}, Book Title: {3}, Pages: {4}, Type: {5}", b.Id, "DELETED", "AUTHOR", b.Title, b.Pages, b.Type);
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
            Book b = GetBookFromId(id);
            string bookTitle = b.Title;
            Books.Remove(b);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The book \"{0}\" has been removed from your library", bookTitle);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DeleteAllBooks()
        {
            Books.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All books from your library has been removed");
            Console.ForegroundColor = ConsoleColor.Gray;
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
        public static Book GetBookFromId(int id)
        {
            try
            {
                return Books.Where(x => x.Id == id).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void GetIdsToChangeAuthorOnBook()
        {
            int authorId = Author.GetAuthorId();
            int bookId = GetBookId();
            ChangeAuthorOnBook(authorId, bookId);
        }
        public static void ChangeAuthorOnBook(int bookId, int authorId)
        {
            Book b = GetBookFromId(bookId);
            int listIndex = Books.IndexOf(b);
            Books[listIndex].AuthorId = authorId;
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("The Author on the book \"{0}\" has been changed from \"{1}\" to \"{2}\"", b.title, oldAuthor.firstName + " " + oldAuthor.lastName, newAuthor.firstName + " " + newAuthor.lastName);
            Console.WriteLine("The book {0} has changed author", b.Title);
            Console.ForegroundColor = ConsoleColor.Gray;


        }

    }
}
