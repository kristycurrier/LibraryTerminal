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

            Dictionary<int, Book> bookList = ParseBookConstructor.ConvertToBook(listOfStrings);

            bool keepGoing = true;

            while (keepGoing == true)
            {
                BookApp.PrintMenu();
                //BookApp.DisplayBooks(bookList);
                int menuChoice = int.Parse(Console.ReadLine());
                int bookKey;
                string userInput;
                switch (menuChoice)
                {
                    case 1:                                                             //Display book list
                        BookApp.DisplayBooks(bookList);
                        break;
                    case 2:                                                             //Search by author name
                        Console.Write("Enter author name: ");
                        userInput = Console.ReadLine();
                        bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                        BookApp.DisplayBook(bookList, bookKey);
                        break;
                    case 3:                                                             //Search by title
                        Console.Write("Enter title of the book: ");
                        userInput = Console.ReadLine();
                        bookKey = BookApp.FindBookByTitle(bookList, userInput);
                        break;
                    case 4:                                                             //check out book
                        Console.WriteLine("How would you like to search for a book to check out? (title or author)");
                        userInput = Console.ReadLine();
                        if (userInput == "title")
                        {
                            Console.Write("Enter title of the book: ");
                            userInput = Console.ReadLine();
                            bookKey = BookApp.FindBookByTitle(bookList, userInput);
                            bookList = BookApp.CheckOutBook(bookList, bookKey);
                        }
                        else if (userInput == "author")
                        {
                            Console.Write("Enter author name: ");
                            userInput = Console.ReadLine();
                            bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                            bookList = BookApp.CheckOutBook(bookList, bookKey);
                        }
                        else { Console.WriteLine("Sorry, not valid"); }
                        break;
                    case 5:                                                             //return book
                        Console.WriteLine("How would you like to search for a book to return? (title or author)");
                        userInput = Console.ReadLine();
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
