using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class ParseBookConstructor : ParseFile
    {
        public static List<Book> ConvertToBookList(List<string> bookListString)
        {

            List<Book> bookList = new List<Book>();
            foreach (var item in bookListString)
            {
                var book = new Book(GetBookTitle(item), GetBookAuthor(item), GetBookStatus(item), GetBookDueDate(item));
                bookList.Add(book);
                Console.WriteLine($"{GetBookTitle(item)} {GetBookAuthor(item)} {Convert.ToString(GetBookStatus(item))} {GetBookDueDate(item).ToString("dd/MM/yyy")}");
            }

            return bookList;
        }

    }
}
