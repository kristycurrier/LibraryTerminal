using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal
{
    class Validator
    {
        static public string DetermineTitleOrAuthor()
        {
            string userInput = Console.ReadLine();
            bool validAnswer = false;

            while (validAnswer == false)
            {
                if (string.IsNullOrEmpty(userInput))   //JA
                {
                    validAnswer = false;
                }
                else if (userInput.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    userInput = "title";
                    validAnswer = true;
                    break;
                }
                else if (userInput.Equals("author", StringComparison.OrdinalIgnoreCase))
                {
                    userInput = "author";
                    validAnswer = true;
                    break;
                }
                else
                {
                    validAnswer = false;
                }
                Console.Write("Invalid, please enter title or author: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static int MenuChoice()
        {
            string menuChoice = Console.ReadLine();
            bool validNumber = false;
            int menuNum = 0;
            while (validNumber == false)
            {
                bool realNumber = int.TryParse(menuChoice, out menuNum);
                if (realNumber == true && menuNum < 6 && menuNum > 0)
                {
                    validNumber = true;
                    break;
                }
                Console.Write("Sorry, that is not a valid menu choice.  Please enter 1-5: ");
                menuChoice = Console.ReadLine();
            }
            return menuNum;
        }
    }
}
