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

            foreach (var book in listOfStrings)
            {
                Console.WriteLine(book);
            }
            listOfStrings.Add("teal");

            FileManagement.WriteFile(listOfStrings, path);

            Console.ReadLine();
        }
    }
}
