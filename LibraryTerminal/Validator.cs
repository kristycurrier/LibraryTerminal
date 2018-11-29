using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class Validator
    {
        //create 2 functions that takes in the user input is a title / author, return bool if it is in the list

        public static bool BookTitleValidator(Dictionary<int, Book> listOfBooks, string userInput)
        {
            bool validBookTitle = false;

                foreach (var book in listOfBooks)
                {
                    if (book.Value.Title.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        validBookTitle = true;
                        break;
                    }
                    else
                    {
                        validBookTitle = false;
                    }
                }
            if (validBookTitle == false)
            {
            Console.WriteLine("That book is not in our collection.");
            }
            return validBookTitle;
        }

        public static bool BookAuthorValidator(Dictionary<int, Book> listOfBooks, string userInput)
        {
            bool validBookAuthor = false;

            foreach (var book in listOfBooks)
            {
                if (book.Value.Title.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    validBookAuthor = true;
                    break;
                }
                else
                {
                    validBookAuthor = false;
                }
            }
            if (validBookAuthor == false)
            {
                Console.WriteLine("That author is not in our collection.");
            }
            return validBookAuthor;
        }
    }
}
