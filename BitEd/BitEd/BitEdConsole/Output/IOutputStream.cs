using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole.Output
{
    interface IOutputStream
    {
        void WriteLine(string text);
        void WriteLine(object obj);
    }
}
