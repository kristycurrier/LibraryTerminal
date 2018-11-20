using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class ParseFile : Book
    {
        public ParseFile(string title, string author, bool status, DateTime dueDate) : base(title, author, status, dueDate)
        {
            title = GetBookTitle();
            author = GetBookAuthor();
            status = GetBookStatus();
            dueDate = GetBookDueDate();

            Console.WriteLine(title, author, status, dueDate);
            Console.ReadLine();

        }
        
        //public static List<Book> ConvertToBook(List<string> bookListString)
        //{




        //    List<string> convertToBook = new List<string>();
        //    convertToBook.Add(GetBookTitle());
        //    convertToBook.Add(GetBookAuthor());
        //    convertToBook.Add(Convert.ToString(GetBookStatus()));
        //    convertToBook.Add(Convert.ToString(GetBookTitle()));

        //    foreach (var section in convertToBook)
        //    {
        //    }

        //}


        public static string GetBookTitle()
        {
            char[] separator = { '_' };
            string str = "The Shining_Stephen King_True_01/06/1988";
            string[] _title = str.Split(separator);
            string title = _title[0];
            Console.WriteLine(title);
            return title;
        }

        public static string GetBookAuthor()
        {
            char[] separator = { '_' };
            string str = "The Shining_Stephen King_True_01/06/1988";
            string[] _author = str.Split(separator);
            string author = _author[1];

            return author;

        }

        public static bool GetBookStatus()
        {
            char[] separator = { '_' };
            string str = "The Shining_Stephen King_True_01/06/1988";
            string[] _status = str.Split(separator);
            bool status = Convert.ToBoolean(_status[2]);

            return status;
        }

        public static DateTime GetBookDueDate()
        {
            char[] separator = { '_' };
            string str = "The Shining_Stephen King_True_01/06/1988";
            string[] _dueDate = str.Split(separator);
            DateTime dueDate = Convert.ToDateTime(_dueDate[3]);

            return dueDate;
        }

    }
}
