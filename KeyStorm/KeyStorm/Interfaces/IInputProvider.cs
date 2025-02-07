using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStorm.Interfaces
{
    /// <summary>
    /// The IInputProvider interface, represents something that provides inputs
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Read the input
        /// </summary>
        /// <returns>The input</returns>
        string Read();

        /// <summary>
        /// Read a single key input
        /// </summary>
        /// <returns>The key input</returns>
        char ReadKey();
    }

}
