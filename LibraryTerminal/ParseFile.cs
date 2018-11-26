using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class ParseFile
    {
        public static List<Book> ConvertToBook(List<string> bookListString)
        {
            List<Book> bookList = new List<Book>();
            foreach (var item in bookListString)
            {
                var book = new Book(GetBookTitle(item), GetBookAuthor(item), GetBookStatus(item), GetBookDueDate(item));
                bookList.Add(book);
            }

            return bookList;
        }

        public static string GetBookTitle(string bookEntry)
        {
            char[] separator = { '_' };
            string str = bookEntry;
            string[] _title = str.Split(separator);
            string title = _title[0];
            return title;
        }

        public static string GetBookAuthor(string bookEntry)
        {
            char[] separator = { '_' };
            string str = bookEntry;
            string[] _author = str.Split(separator);
            string author = _author[1];
            return author;

        }

        public static bool GetBookStatus(string bookEntry)
        {
            char[] separator = { '_' };
            string str = bookEntry;
            string[] _status = str.Split(separator);
            bool status = Convert.ToBoolean(_status[2]);
            return status;
        }

        public static DateTime GetBookDueDate(string bookEntry)
        {
            char[] separator = { '_' };
            string str = Convert.ToString(bookEntry);
            string[] _dueDate = str.Split(separator);
            DateTime dueDate = Convert.ToDateTime(_dueDate[3]);
            return dueDate;
        }
    }
}
