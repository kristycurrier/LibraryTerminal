﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class Validator
    {
        static public string DetermineTitleOrAuthor()
        {
            string userInput = Console.ReadLine();
            bool validAnswer = false;

            while (validAnswer == false)
            {
                if (string.IsNullOrEmpty(userInput))   //JA
                {
                    validAnswer = false;
                }
                else if (userInput.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    userInput = "title";
                    validAnswer = true;
                    break;
                }
                else if (userInput.Equals("author", StringComparison.OrdinalIgnoreCase))
                {
                    userInput = "author";
                    validAnswer = true;
                    break;
                }
                else
                {
                    validAnswer = false;
                }
                Console.Write("Invalid, please enter title or author: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static int MenuChoice()
        {
            string menuChoice = Console.ReadLine();
            bool validNumber = false;
            int menuNum = 0;
            while (validNumber == false)
            {
                bool realNumber = int.TryParse(menuChoice, out menuNum);
                if (realNumber == true && menuNum < 8 && menuNum > 0)
                {
                    validNumber = true;
                    break;
                }
                Console.Write("Sorry, that is not a valid menu choice.  Please enter 1-6 (DEFINITELY NOT 7): ");
                menuChoice = Console.ReadLine();
            }
            return menuNum;
        }

        public static bool BookTitleValidator(Dictionary<int, Book> listOfBooks, string userInput)
        {
            bool validBookTitle = false;

            foreach (var book in listOfBooks)
            {
                if (book.Value.Title.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    validBookTitle = true;
                    break;
                }
                else
                {
                    validBookTitle = false;
                }
            }
            if (validBookTitle == false)
            {
                Console.WriteLine("That book is not in our collection.");
            }
            return validBookTitle;
        }

        public static bool BookAuthorValidator(Dictionary<int, Book> listOfBooks, string userInput)
        {
            bool validBookAuthor = false;

            foreach (var book in listOfBooks)
            {
                if (book.Value.Author.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    validBookAuthor = true;
                    break;
                }
                else
                {
                    validBookAuthor = false;
                }
            }
            if (validBookAuthor == false)
            {
                Console.WriteLine("That author is not in our collection.");
            }
            return validBookAuthor;
        }

        public static bool YesNoAnswer()
        {
            bool keepGoing = true;
            bool validInput = false;
            string userInput = Console.ReadLine();

            while (validInput == false)
            {
                if (userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    keepGoing = true;
                    validInput = true;
                }
                else if (userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    keepGoing = false;
                    validInput = true;
                }
                else
                {
                    Console.Write("Enter y for yes or n for no: ");
                    userInput = Console.ReadLine();
                }
            }
            return keepGoing;
        }

        public static string NewBookTitleValidator()
        {
            bool validNewBookTitle = false;
            string userInput = Console.ReadLine();

            while (validNewBookTitle == false)
            {
                if (userInput.Length == 0)
                {
                    validNewBookTitle = false;
                }
                else
                {
                    validNewBookTitle = true;
                    break;
                }
                Console.Write("Sorry not a valid title, please enter a valid title: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static string NewBookAuthorValidator()
        {
            bool validNewBookAuthor = false;
            string userInput = Console.ReadLine();

            while (validNewBookAuthor == false)
            {
                if (userInput.Length == 0)
                {
                    validNewBookAuthor = false;
                }
                else
                {
                    validNewBookAuthor = true;
                    break;
                }
                Console.Write("Sorry not a valid author, please enter a valid author: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
    }
}
