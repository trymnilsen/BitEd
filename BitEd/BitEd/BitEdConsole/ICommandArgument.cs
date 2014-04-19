using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole
{
    internal interface ICommandArgument
    {
        string Name { get; set; }

        void SetFlags(CommandEnvironment environment);
        void Execute(string[] commands);
        string ToHelp();
    }
}
