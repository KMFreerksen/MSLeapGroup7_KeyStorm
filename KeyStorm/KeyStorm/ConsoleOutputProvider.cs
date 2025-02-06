using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyStorm.Interfaces;

namespace KeyStorm
{
    /// <summary>
    /// Ths ConsoleOutputProvider class, provides outputs to the Console
    /// </summary>
    class ConsoleOutputProvider : IOutputProvider
    {
        /// <summary>
        /// Write the specified output to the console
        /// </summary>
        /// <param name="output">The output</param>
        public void Write(string output)
        {
            Console.Write(output);
        }

        /// <summary>
        /// Write the output with a new line
        /// </summary>
        /// <param name="output"></param>
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Write an empty new line
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Clear the output
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
