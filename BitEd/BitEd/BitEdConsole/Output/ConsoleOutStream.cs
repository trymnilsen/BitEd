using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole.Output
{
    internal class ConsoleOutStream:IOutputStream
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
