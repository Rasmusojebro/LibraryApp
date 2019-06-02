﻿using System;
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
            Console.ReadLine();
           
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
                Console.WriteLine("{0} is not a valid input, try again", userInput);
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
                case 0:
                    break;
                default:
                    break;
            }
        }
        private static void AddDefaultObjects()
        {
            Author a = new Author("Rasmus", "Öjebro");
            Author a1 = new Author("Lucas", "Rohlin");
            Author a2 = new Author("Stephen", "King");

            SmallBook b = new SmallBook(a, "Livet om Rasmus", 132);
            MediumBook b1 = new MediumBook(a1, "Lucas Resa", 510);
            LargeBook b2 = new LargeBook(a2, "IT", 923);
        }

    }
}