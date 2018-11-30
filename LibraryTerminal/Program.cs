using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = FileManagement.GetPath();
            List<string> listOfStrings = FileManagement.ReadFile(path);
            Dictionary<int, Book> bookList = ParseFile.ConvertToBook(listOfStrings);
            bookList = BookApp.CheckInBooks(bookList);

            bool keepGoing = true;

            while (keepGoing == true)
            {
                BookApp.PrintMenu();

                int menuChoice = Validator.MenuChoice();
                int bookKey;
                string userInput;
                bool validAuthor;
                bool validTitle;
                bool onShelf;
                switch (menuChoice)
                {
                    case 1:                                                             //Display book list
                        BookApp.DisplayBooks(bookList);
                        break;
                    case 2:                                                             //Search by author name
                        Console.Write("Enter author name: ");
                        userInput = Console.ReadLine();
                        validAuthor = Validator.BookAuthorValidator(bookList, userInput);
                        if (validAuthor == true)
                        {
                            bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                            onShelf = BookApp.DisplayBook(bookList, bookKey);
                            if (onShelf)
                            {
                                Console.WriteLine("Would you like to check that book out? (y/n)");
                                if (Validator.YesNoAnswer())
                                {
                                    bookList = BookApp.CheckOutBook(bookList, bookKey);
                                }
                            }
                        }

                        break;
                    case 3:                                                             //Search by title
                        Console.Write("Enter title of the book: ");
                        userInput = Console.ReadLine();
                        validTitle = Validator.BookTitleValidator(bookList, userInput);
                        if (validTitle == true)
                        {
                            bookKey = BookApp.FindBookByTitle(bookList, userInput);
                            onShelf = BookApp.DisplayBook(bookList, bookKey);
                            if (onShelf)
                            {
                                Console.WriteLine("Would you like to check that book out? (y/n)");
                                if (Validator.YesNoAnswer())
                                {
                                    bookList = BookApp.CheckOutBook(bookList, bookKey);
                                }
                            }
                        }
                        break;
                    case 4:                                                             //check out book
                        Console.WriteLine("How would you like to search for a book to check out? (title or author)");
                        userInput = Validator.DetermineTitleOrAuthor();
                        if (userInput == "title")
                        {
                            Console.Write("Enter title of the book: ");
                            userInput = Console.ReadLine();
                            if (validTitle = Validator.BookTitleValidator(bookList, userInput))
                            {
                                bookKey = BookApp.FindBookByTitle(bookList, userInput);
                                bookList = BookApp.CheckOutBook(bookList, bookKey);
                            }
                        }
                        else if (userInput == "author")
                        {
                            Console.Write("Enter author name: ");
                            userInput = Console.ReadLine();
                            if(validAuthor = Validator.BookAuthorValidator(bookList, userInput))
                            {
                            bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                            bookList = BookApp.CheckOutBook(bookList, bookKey);
                            }

                        }
                        else { Console.WriteLine("Sorry, not valid"); }
                        break;
                    case 5:                                                             //return book
                        Console.WriteLine("How would you like to search for a book to return? (title or author)");
                        userInput = Validator.DetermineTitleOrAuthor();
                        if (userInput == "title")
                        {
                            Console.Write("Enter title of the book: ");
                            userInput = Console.ReadLine();
                            bookKey = BookApp.FindBookByTitle(bookList, userInput);
                            bookList = BookApp.ReturnBook(bookList, bookKey);
                        }
                        else if (userInput == "author")
                        {
                            Console.Write("Enter author name: ");
                            userInput = Console.ReadLine();
                            bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                            bookList = BookApp.ReturnBook(bookList, bookKey);
                        }
                        else { Console.WriteLine("Sorry, not valid"); }
                        break;
                    default:
                        Console.WriteLine("Sorry, that wasn't a valid choice.");
                        break;
                }

                keepGoing = BookApp.ContinueTheProgram();
            }

            listOfStrings = FileManagement.CreateListFromDictonary(bookList);
            FileManagement.WriteFile(listOfStrings, path);

            Console.ReadLine();
        }
    }
}
