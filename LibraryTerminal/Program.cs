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

                switch (menuChoice)
                {
                    case 1:                                                             //Display book list
                        BookApp.DisplayBooks(bookList);
                        break;
                    case 2:                                                             //Search by author
                        bookList = ProgramApp.SearchByAuthor(bookList);
                        break;
                    case 3:                                                             //search by title
                        bookList = ProgramApp.SearchByTitle(bookList);
                        break;
                    case 4:                                                             //check out book
                        bookList = ProgramApp.CheckOutBook(bookList);
                        break;
                    case 5:                                                             //return book
                        bookList = ProgramApp.ReturnBook(bookList);
                        break;
                    case 6:
                        bookList = ProgramApp.AddBook(bookList);
                        break;
                    case 7:
                        ProgramApp.EasterEgg();
                        break;
                    default:
                        Console.WriteLine("Sorry, that wasn't a valid choice.");
                        break;
                }

                keepGoing = BookApp.ContinueTheProgram();
                Console.Clear();
            }

            listOfStrings = FileManagement.CreateListFromDictonary(bookList);
            FileManagement.WriteFile(listOfStrings, path);

            Console.ReadLine();
        }
    }
}
