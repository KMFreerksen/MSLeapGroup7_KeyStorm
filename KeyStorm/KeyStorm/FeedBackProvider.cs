using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStorm
{
    public class FeedbackProvider
    {
        public void ProvideFeedback(char inputChar, char expectedChar)
        {
            if (inputChar == expectedChar)
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }

            Console.Write(inputChar);
            Console.ResetColor();
        }
    }
}
