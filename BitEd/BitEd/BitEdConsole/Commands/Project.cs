using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole.Commands
{
    public class Project : ICommandArgument
    {
        public string Name { get; set; }

        public Project()
        {
            Name = "init";
        }
        public void SetFlags(CommandEnvironment environment)
        {
            throw new NotImplementedException();
        }

        public void Execute(string[] commands)
        {
            Console.Write("Creating Project " + commands[0]);
        }

        public string ToHelp()
        {
            throw new NotImplementedException();
        }
    }
}
