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

        public static List<string> ReadFile(string path)
        {
            List<string> libraryCollection = new List<string>();
            string line;

            using (var reader = new StreamReader(path))
            {
                do
                {
                    line = reader.ReadLine();

                    if(line == null)
                    { break; }

                    libraryCollection.Add(line);
                } while (line != null);

            }
            return libraryCollection;
        }

        public static void WriteFile(List<string> libraryList, string path)
        {
            File.WriteAllLines(path, libraryList);
        }


        //string sentence = "Title_Author_true_01/01/1900";
        //string[] words = sentence.Split('_');
    }
}
