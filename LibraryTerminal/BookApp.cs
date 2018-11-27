using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class BookApp
    {
        public static void DisplayBooks(Dictionary<int,Book> listOfBooks)
        {
            Console.WriteLine("List of books: ");
            Console.Write("{0,-30} {1,-20} {2,-10} {3,-10}\n", "Title", "Author", "On Shelf", "Due Date");
            Console.Write("{0,-30} {0,-20} {0,-10} {0,-10}\n", "-----");

            foreach (var book in listOfBooks)
            {
                Console.WriteLine("{0,-30} {1,-20} {2,-10} {3,-10}", book.Value.Title, book.Value.Author, book.Value.Status, book.Value.DueDate.ToString("d"));
            }
        }

        public static void DisplayBook(Dictionary<int, Book> listOfBooks, int keyNum)
        {
            Console.WriteLine("{0,-30} {1,-20} {2,-10} {3,-10}", listOfBooks[keyNum].Title, listOfBooks[keyNum].Author, listOfBooks[keyNum].Status, listOfBooks[keyNum].DueDate.ToString("d"));
        }

        public static void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Display list of books.");
            Console.WriteLine("2. Search library by author name.");
            Console.WriteLine("3. Search library by title of book.");
            Console.WriteLine("4. Check out a book.");
            Console.WriteLine("5. Return a book");
            Console.Write("Selection: ");
        }

        public static int FindBookByAuthor(Dictionary<int, Book> listOfBooks,string userInput)
        {
            int bookSelection = 0;

            foreach (var book in listOfBooks)
            {
                if (book.Value.Author == userInput)
                {
                    bookSelection = book.Key;
                    break;
                }
            }
            return bookSelection;
        }

        public static int FindBookByTitle(Dictionary<int,Book> listOfBooks, string userInput)
        {
            int bookSelection = 0;

            foreach (var book in listOfBooks)
            {
                if (book.Value.Title == userInput)
                {
                    bookSelection = book.Key;
                    break;
                }
            }
            return bookSelection;
        }

        public static Dictionary<int, Book> CheckOutBook(Dictionary<int,Book> bookList, int bookNum)
        {
            bookList[bookNum].Status = false;
            DateTime today = DateTime.Now.Date;
            bookList[bookNum].DueDate = today.AddDays(14);
            return bookList;
        }

        public static Dictionary<int, Book> ReturnBook(Dictionary<int, Book> bookList, int bookNum)
        {
            bookList[bookNum].Status = true;
            bookList[bookNum].DueDate = Convert.ToDateTime("01/01/1900");
            return bookList;
        }

        public static bool ContinueTheProgram()
        {
            bool keepGoing = true;
            Console.WriteLine("Would you like to continue the program? (y/n)");
            string userInput = Console.ReadLine();
            if(userInput == "y")
            {
                keepGoing = true;
            }else if (userInput == "n")
            {
                keepGoing = false;
            }
            else { }
            return keepGoing;
        }
    }
}
