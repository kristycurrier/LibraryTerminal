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
                      
            string path = FileManagement.GetPath();

            List<string> listOfStrings = FileManagement.ReadFile(path);

            foreach(var book in listOfStrings)
            {
                Console.WriteLine(book);
            }

            FileManagement.WriteFile(listOfStrings, path);

            Console.ReadLine();
        }
    }
}
