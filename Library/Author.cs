using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Author
    {
        public int id;
        public static int nextId = 0;
        public string firstName;
        public string lastName;
        public static List<Author> authors = new List<Author>();

        public Author(string first, string last)
        {
            id = nextId;
            firstName = first;
            lastName = last;
            authors.Add(this);
            nextId++;
        }

        public static void ListAllAuthors()
        {
            Console.WriteLine();
            foreach (Author a in authors)
            {
                Console.WriteLine("ID: {0}, Name: {1} {2}", a.id, a.firstName, a.lastName);
            }
        }

        public static void AddNewAuthor()
        {
            string firstName = AddFirstNameForNewAuthor();
            string lastName = AddLastNameForNewAuthor();
            Author a = new Author(firstName, lastName);
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
            Author a = GetAuthorFromId(authorId);
            DeleteAuthorWithAuthor(a);
        }

        public static void DeleteAuthorWithAuthor(Author a)
        {
            string authorName = a.firstName + " " + a.lastName;
            authors.Remove(a);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The author \"{0}\" has been removed", authorName);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DeleteAllAuthors()
        {
            authors.Clear();
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
                return authors.Where(x => x.id == id).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ListAllBooksFromSpecificAuthor()
        {
            int authorId = GetAuthorId();
            List<Books> booksOfSpecificAuthor = Books.books.Where(x => x.authorId == authorId).ToList();
            foreach (Books b in booksOfSpecificAuthor)
            {
                Books.WriteBook(b);
            }
        }
    }
}
