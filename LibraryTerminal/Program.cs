using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {

            Book firstBook = new Book("Title", "Author", true, DateTime.Parse("01/01/1900"));
            Console.WriteLine(firstBook.Author);




            Console.ReadLine();

        }
    }
}
