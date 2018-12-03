using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class ProgramApp
    {
        public static Dictionary<int, Book> ActionFromList(Dictionary<int, Book> bookList)
        {
            Console.Write("\nWould you like to select a book? (y/n) ");
            if(Validator.YesNoAnswer())
            {
                bool validNumber = false;
                int bookNum = 0;
                while (validNumber == false)
                {
                    Console.Write($"Please select a book 1 through {bookList.Count}: ");
                    bool realNumber = int.TryParse(Console.ReadLine(), out bookNum);
                    if (realNumber == true && bookNum > 0 && bookNum <= bookList.Count)
                    {
                        validNumber = true;
                    }
                }

                if(bookList[bookNum].Status == true)
                {
                    Console.Write($"Would you like to check {bookList[bookNum].Title} out? (y/n) ");
                    if (Validator.YesNoAnswer())
                    {
                        bookList = BookApp.CheckOutBook(bookList, bookNum);
                    }
                } else if (bookList[bookNum].Status == false)
                {
                    Console.Write($"Would you like to return {bookList[bookNum].Title}? (y/n) ");
                    if (Validator.YesNoAnswer())
                    {
                        bookList = BookApp.ReturnBook(bookList, bookNum);
                    }
                }
            }
            return bookList;
        }

        public static Dictionary<int, Book> SearchByAuthor(Dictionary<int, Book> bookList)
        {
            Console.Write("Enter author name: ");
            string userInput = Console.ReadLine();
            bool validAuthor = Validator.BookAuthorValidator(bookList, userInput);
            if (validAuthor == true)
            {
                int bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                bool onShelf = BookApp.DisplayBook(bookList, bookKey);
                if (onShelf)
                {
                    Console.WriteLine("Would you like to check that book out? (y/n)");
                    if (Validator.YesNoAnswer())
                    {
                        bookList = BookApp.CheckOutBook(bookList, bookKey);
                    }
                }
            }
            return bookList;
        }

        public static Dictionary<int, Book> SearchByTitle(Dictionary<int, Book> bookList)
        {
            Console.Write("Enter title of the book: ");
            string userInput = Console.ReadLine();
            bool validTitle = Validator.BookTitleValidator(bookList, userInput);
            if (validTitle == true)
            {
                int bookKey = BookApp.FindBookByTitle(bookList, userInput);
                bool onShelf = BookApp.DisplayBook(bookList, bookKey);
                if (onShelf)
                {
                    Console.Write("Would you like to check that book out? (y/n) ");
                    if (Validator.YesNoAnswer())
                    {
                        bookList = BookApp.CheckOutBook(bookList, bookKey);
                    }
                }
            }
            return bookList;
        }

        public static Dictionary<int, Book> CheckOutBook(Dictionary<int, Book> bookList)
        {
            Console.WriteLine("How would you like to search for a book to check out? (title or author)");
            string userInput = Validator.DetermineTitleOrAuthor();
            bool validTitle;
            bool validAuthor;
            if (userInput == "title")
            {
                Console.Write("Enter title of the book: ");
                userInput = Console.ReadLine();
                if (validTitle = Validator.BookTitleValidator(bookList, userInput))
                {
                    int bookKey = BookApp.FindBookByTitle(bookList, userInput);
                    if (bookList[bookKey].Status == true)
                    {
                        bookList = BookApp.CheckOutBook(bookList, bookKey);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that book is already checked out.");
                    }
                }
            }
            else if (userInput == "author")
            {
                Console.Write("Enter author name: ");
                userInput = Console.ReadLine();
                if (validAuthor = Validator.BookAuthorValidator(bookList, userInput))
                {
                    int bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                    if (bookList[bookKey].Status == true)
                    {
                        bookList = BookApp.CheckOutBook(bookList, bookKey);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that book is already checked out.");
                    }
                }
            }
            else { Console.WriteLine("Sorry, not valid"); }

            return bookList;
        }

        public static Dictionary<int, Book> ReturnBook(Dictionary<int, Book> bookList)
        {
            Console.WriteLine("How would you like to search for a book to return? (title or author)");
            string userInput = Validator.DetermineTitleOrAuthor();
            if (userInput == "title")
            {
                Console.Write("Enter title of the book: ");
                userInput = Console.ReadLine();
                bool validTitle;
                if (validTitle = Validator.BookTitleValidator(bookList, userInput))
                {
                    int bookKey = BookApp.FindBookByTitle(bookList, userInput);
                    bookList = BookApp.ReturnBook(bookList, bookKey);
                }
            }
            else if (userInput == "author")
            {
                Console.Write("Enter author name: ");
                userInput = Console.ReadLine();
                bool validAuthor;
                if (validAuthor = Validator.BookAuthorValidator(bookList, userInput))
                {
                    int bookKey = BookApp.FindBookByAuthor(bookList, userInput);
                    bookList = BookApp.ReturnBook(bookList, bookKey);
                }
            }
            else { Console.WriteLine("Sorry, not valid"); }

            return bookList;
        }

        public static Dictionary<int, Book> AddBook(Dictionary<int, Book> bookList)
        {
            string newBookTitle;
            string newBookAuthor ;

            Console.Write("Enter title: ");
            newBookTitle = Validator.NewBookTitleValidator();

            Console.Write("Enter author: ");
            newBookAuthor = Validator.NewBookAuthorValidator();

            Console.WriteLine("Are you sure you want to add this book to the library? (y/n)");
            bool yesAnswer = Validator.YesNoAnswer();
            if (yesAnswer == true)
            {
                Console.WriteLine($"You've added {newBookTitle} by {newBookAuthor}");
                Book newBook = new Book(newBookTitle, newBookAuthor, true, Convert.ToDateTime("01/01/1900"));
                bookList.Add(bookList.Count + 1, newBook);

            }
            else {Console.WriteLine("No prob, please consider donating to the library at another time");}

            return bookList;
        }

        public static void EasterEgg()
        {
            Process.Start("http://minesweeperonline.com/");
        }

    }
}
