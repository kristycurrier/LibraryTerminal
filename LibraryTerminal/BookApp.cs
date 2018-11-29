using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class BookApp
    {
        public static Dictionary<int, Book> CheckInBooks(Dictionary<int, Book> listOfBooks)
        {
            foreach (var book in listOfBooks)
            {
                if (book.Value.DueDate <= DateTime.Now)
                {
                    book.Value.Status = true;
                    book.Value.DueDate = Convert.ToDateTime("01/01/1900");
                }
            }
            return listOfBooks;
        }

        public static void DisplayBooks(Dictionary<int, Book> listOfBooks)
        {
            Console.WriteLine("");
            Console.Write("{0,-30} {1,-20} {2,-10} {3,-10}\n", "Title", "Author", "On Shelf", "Due Date");
            Console.Write("{0,-30} {0,-20} {0,-10} {0,-10}\n", "-----");

            foreach (var book in listOfBooks)
            {
                if (book.Value.DueDate == Convert.ToDateTime("01/01/1900"))
                {
                    Console.WriteLine("{0,-30} {1,-20} {2,-10}", book.Value.Title, book.Value.Author, book.Value.Status);
                }
                else
                {
                    Console.WriteLine("{0,-30} {1,-20} {2,-10} {3,-10}", book.Value.Title, book.Value.Author, book.Value.Status, book.Value.DueDate.ToString("d"));
                }
            }
        }

        public static bool DisplayBook(Dictionary<int, Book> listOfBooks, int keyNum)
        {
            if (listOfBooks[keyNum].Status == true)
            {
                Console.WriteLine("{0,-30} {1,-20} {2,-10}", listOfBooks[keyNum].Title, listOfBooks[keyNum].Author, "On shelf");
            }
            else
            {
                Console.WriteLine("{0,-30} {1,-20} {2,-15} {3,-10}", listOfBooks[keyNum].Title, listOfBooks[keyNum].Author, "Checked out", "Due Date: " + listOfBooks[keyNum].DueDate.ToString("d"));
            }
            return listOfBooks[keyNum].Status;
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

        public static int FindBookByAuthor(Dictionary<int, Book> listOfBooks, string userInput)
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

        public static int FindBookByTitle(Dictionary<int, Book> listOfBooks, string userInput)
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

        public static Dictionary<int, Book> CheckOutBook(Dictionary<int, Book> bookList, int bookNum)
        {
            bookList[bookNum].Status = false;
            DateTime today = DateTime.Now.Date;
            bookList[bookNum].DueDate = today.AddDays(14);
            Console.WriteLine($"You checked out {bookList[bookNum].Title}.");
            return bookList;
        }

        public static Dictionary<int, Book> ReturnBook(Dictionary<int, Book> bookList, int bookNum)
        {
            if (bookList[bookNum].DueDate != Convert.ToDateTime("01/01/1900"))
            {
                bookList[bookNum].Status = true;
                bookList[bookNum].DueDate = Convert.ToDateTime("01/01/1900");
                Console.WriteLine($"You returned {bookList[bookNum].Title}.");
            }
            else
            {
                Console.WriteLine("That book is already on the shelf.");
            }
            return bookList;
        }

        public static bool ContinueTheProgram()
        {
            bool keepGoing = true;
            Console.Write("\nWould you like to continue the program? (y/n) ");
            keepGoing = Validator.YesNoAnswer();
            Console.WriteLine("");
            return keepGoing;
        }
    }
}
