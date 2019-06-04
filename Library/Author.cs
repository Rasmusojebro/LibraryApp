using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Author
    {
        public int Id;
        public static int NextId = 0;
        public string FirstName;
        public string LastName;
        public static List<Author> Authors = new List<Author>();

        public Author(string first, string last)
        {
            Id = NextId;
            FirstName = first;
            LastName = last;
            Authors.Add(this);
            NextId++;
        }

        public static void ListAllAuthors()
        {
            Console.WriteLine();
            foreach (Author a in Authors)
            {
                Console.WriteLine("ID: {0}, Name: {1} {2}", a.Id, a.FirstName, a.LastName);
            }
        }

        public static void AddNewAuthor()
        {
            string firstName = AddFirstNameForNewAuthor();
            string lastName = AddLastNameForNewAuthor();
            Author author = new Author(firstName, lastName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} {1} has been added as new Author", firstName, lastName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string AddFirstNameForNewAuthor()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Authors first name:");
            return Console.ReadLine();
        }

        private static string AddLastNameForNewAuthor()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Authors last name:");
            return Console.ReadLine();
        }

        public static void DeleteAuthor()
        {
            int authorId = GetAuthorId();
            Author author = GetAuthorFromId(authorId);
            DeleteAuthorWithAuthor(author);
        }

        public static void DeleteAuthorWithAuthor(Author author)
        {
            string authorName = author.FirstName + " " + author.LastName;
            Authors.Remove(author);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The author \"{0}\" has been removed", authorName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DeleteAllAuthors()
        {
            Authors.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All authors has been removed");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static int GetAuthorId()
        {
            ListAllAuthors();
            Console.WriteLine("Enter the ID of the author you want to chose for this action:");
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
                GetAuthorId();
            }
            return 0;
        }

        public static Author GetAuthorFromId(int id)
        {
            try
            {
                return Authors.Where(x => x.Id == id).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Book> GetAllBooksFromSpecificAuthor(int authorId)
        {
            return Book.Books.Where(x => x.AuthorId == authorId).ToList();
        }
        public static void ListAllBooksFromSpecificAuthor()
        {
            int authorId = GetAuthorId();
            List<Book> booksOfSpecificAuthor = GetAllBooksFromSpecificAuthor(authorId);
            
            foreach (Book book in booksOfSpecificAuthor)
            {
                Book.WriteBook(book);
            }
        }
    }
}
