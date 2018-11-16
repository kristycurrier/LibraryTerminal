using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class FileManagement
    {
        public static string GetPath()
        {
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string path = Path.Combine(directory, "BookList.txt");
            return path;
        }

        public static void ReadFile(string path)
        {
            string line;
            using (var reader = new StreamReader(path))
            {
                do
                {

                    line = reader.ReadLine();
                    Console.WriteLine(line);
                } while (line != null);
            }
        }
        //read method 
        //write method
        //only deals with strings



        //string sentence = "Title_Author_true_01/01/1900";
        //string[] words = sentence.Split('_');
        //i/o file write/read lists
    }
}
