using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    public class Book
    { 
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }

        public Book(string title, string author, bool status, DateTime dueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
        }
    }
}
