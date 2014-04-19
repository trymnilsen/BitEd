using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = new CommandParser(args);
            parser.Parse();
        }
    }
}
