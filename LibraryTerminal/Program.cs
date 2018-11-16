using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

            //string text = File.ReadAllText(FileManagement.GetPath());
            string text2 = FileManagement.GetPath();
            FileManagement.ReadFile(text2);

            //Console.WriteLine(text);
            //Console.WriteLine(text2);



            Console.ReadLine();

        }
    }
}
