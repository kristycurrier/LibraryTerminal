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

            List<Book> bookList = ParseBookConstructor.ConvertToBook(listOfStrings);

            BookApp.DisplayBooks(bookList);
            //Book book = BookApp.FindBookByAuthor(bookList, "Jane Austen");
            //Console.WriteLine(book.Title);
            //FileManagement.WriteFile(listOfStrings, path);

            Console.ReadLine();
        }
    }
}
