using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class BookApp
    {
        public static void DisplayBooks(List<Book> listOfBooks)
        {
            Console.WriteLine("List of books: ");
            Console.Write("{0,-30} {1,-20} {2,-10} {3,-10}\n", "Title", "Author", "On Shelf", "Due Date");
            Console.Write("{0,-30} {0,-20} {0,-10} {0,-10}\n", "-----");
            foreach (var book in listOfBooks)
            {
                Console.WriteLine("{0,-30} {1,-20} {2,-10} {3,-10}", book.Title, book.Author, book.Status, book.DueDate);
            }
        }

        public static Book FindBookByAuthor(List<Book> listOfBooks,string userInput)
        {
            Book bookSelection = new Book("","",true, DateTime.Now);

            foreach (var book in listOfBooks)
            {
                if (book.Author == userInput)
                {
                    bookSelection = book;
                    break;
                }
            }
            return bookSelection;
        }

        public static Book FindBookByTitle(List<Book> listOfBooks, string userInput)
        {
            Book bookSelection = new Book("", "", true, DateTime.Now);

            foreach (var book in listOfBooks)
            {
                if (book.Title == userInput)
                {
                    bookSelection = book;
                    break;
                }
            }
            return bookSelection;
        }

    }
}
