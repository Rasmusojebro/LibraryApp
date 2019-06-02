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
            foreach (Author a in authors)
            {
                Console.WriteLine(a.id + ": " + a.firstName + " " + a.lastName);
            }
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
        public static void AddNewAuthor()
        {
            string firstName = GetFirstNameForNewAuthor();
            string lastName = GetLastNameForNewAuthor();
            Author a = new Author(firstName, lastName);
            Console.WriteLine("{0} {1} has been added as new Author", firstName, lastName);
        }
        private static string GetFirstNameForNewAuthor()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Authors first name:");
            return Console.ReadLine();
        }
        private static string GetLastNameForNewAuthor()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Authors last name:");
            return Console.ReadLine();
        }
        public static void DeleteAuthor()
        {
            ListAllAuthors();
            Console.WriteLine();
            Console.WriteLine("Enter the ID of the author you want to delete:");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                DeleteAuthorFromId(userInputNumeric);
            }
            else
            {
                Console.WriteLine("{0} is not a valid input, try again", userInput);
                DeleteAuthor();
            }
        }
        public static void DeleteAuthorFromId(int id)
        {
            Author a = GetAuthorFromId(id);
            authors.Remove(a);
        }

        public static void DeleteAllAuthors()
        {
            authors.Clear();
        }
    }
}
