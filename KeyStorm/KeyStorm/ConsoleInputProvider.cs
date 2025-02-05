using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyStorm.Interfaces;

namespace KeyStorm
{
    /// <summary>
    /// Ths ConsoleInputProvider class, provides inputs from the Console
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Read a line from the console
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
