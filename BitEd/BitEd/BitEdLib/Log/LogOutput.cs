using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Log
{
    public interface LogOutput
    {
        void Write(String Line);
    }
}
