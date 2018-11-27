using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class ParseBookConstructor : ParseFile
    {
        public static Dictionary<int,Book> ConvertToBookList(List<string> bookListString)
        {
            Dictionary<int, Book> bookList = new Dictionary<int,Book>();
            int counter = 1;
            foreach (var item in bookListString)
            {
                var book = new Book(GetBookTitle(item), GetBookAuthor(item), GetBookStatus(item), GetBookDueDate(item));
                bookList.Add(counter, book);
                //Console.WriteLine($"{GetBookTitle(item)} {GetBookAuthor(item)} {Convert.ToString(GetBookStatus(item))} {GetBookDueDate(item).ToString("dd/MM/yyy")}");
                counter++;
            }
            return bookList;
        }

    }
}
