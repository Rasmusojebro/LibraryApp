using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            AddDefaultObjects();
            Menu();
        }
        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---MENY---");
            Console.WriteLine("1 - List all Authors");
            Console.WriteLine("2 - Add new Author");
            Console.WriteLine("3 - List all books");
            Console.WriteLine("4 - Add new Book");
            Console.WriteLine("5 - Delete Author");
            Console.WriteLine("6 - Delete Book");
            Console.WriteLine("7 - Delete all Authors");
            Console.WriteLine("8 - Delete all Books");
            Console.WriteLine("9 - Get All Books From Specific Author");
            Console.WriteLine("10 - Change Author on Book");
            Console.WriteLine("0 - Close Program");
            string userInput = Console.ReadLine();
            int userInputNumeric;
            bool userInputIsNumeric = int.TryParse(userInput, out userInputNumeric);
            if (userInputIsNumeric)
            {
                MenuOptions(userInputNumeric);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} is not a valid input, try again", userInput);
                Console.ForegroundColor = ConsoleColor.Gray;
                Menu();
            }


        }
        private static void MenuOptions(int input)
        {
            switch (input)
            {
                case 1:
                    Author.ListAllAuthors();
                    Menu();
                    break;
                case 2:
                    Author.AddNewAuthor();
                    Menu();
                    break;
                case 3:
                    Books.ListAllBooks();
                    Menu();
                    break;
                case 4:
                    Books.AddNewBook();
                    Menu();
                    break;
                case 5:
                    Author.DeleteAuthor();
                    Menu();
                    break;
                case 6:
                    Books.DeleteBook();
                    Menu();
                    break;
                case 7:
                    Author.DeleteAllAuthors();
                    Menu();
                    break;
                case 8:
                    Books.DeleteAllBooks();
                    Menu();
                    break;
                case 9:
                    Author.ListAllBooksFromSpecificAuthor();
                    Menu();
                    break;
                case 10:
                    Books.ChangeAuthorOnBook();
                    Menu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        private static void AddDefaultObjects()
        {
            Author a = new Author("Lane", "Hobson");
            Author a1 = new Author("Andrew W", "Trask");
            Author a2 = new Author("Alex", "Matroosov");
            Author a3 = new Author("Joseph", "Albahari");
            Author a4 = new Author("Robert C", "Martin");

            new MediumBook(a, "Natural Language Processing in Action", 300);
            new MediumBook(a1, "Grokking Deep Learning", 359);
            new MediumBook(a2, "Rootkits And Bootkits", 504);
            new LargeBook(a3, "C# 7.0 in a Nutshell", 1056);
            new SmallBook(a3, "LINQ Pocket Reference", 172);
            new MediumBook(a4, "Clean Code: A Handbook of Agile Software Craftmanship", 464);
        }

    }
}
