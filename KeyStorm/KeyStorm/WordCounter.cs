using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStorm
{
    class WordCounter
    {
        public double CalculateWPM(string input, double totalTimeInSeconds)
        {
            if (string.IsNullOrWhiteSpace(input) || totalTimeInSeconds <= 0)
            {
                return 0; // Return 0 if the input is empty or the time is invalid
            }

            // Split the input into words
            int wordCount = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            // Calculate the words per minute
            double totalMinutes = totalTimeInSeconds / 60;
            return wordCount / totalMinutes;
        }
    }
}

