using BitEdConsole.Commands;
using BitEdConsole.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole
{
    internal class CommandParser
    {
        private string[] rawArgs;
        private Dictionary<string, ICommandArgument> commands;
        private OutputWriter outputWriteStream;
        public CommandParser(string[] args)
        {
            this.rawArgs = args;
            commands = new Dictionary<string, ICommandArgument>();
            generateCommands();
            //outputWriteStream = new OutputWriter();
        }
        private void generateCommands()
        {
            commands.Add("init",new Project());
        }
        public void Parse()
        {
            ICommandArgument requestedCommand = null;
            string command = "";
            //Loop through all Arguments
            for(int i=0; i<rawArgs.Length; i++)
            {
                //Current command
                command = rawArgs[i];
                //Do we have a command matching this argument
                if(commands.ContainsKey(command))
                {
                    //No commands has been found until now
                    if(requestedCommand==null)
                    {
                        requestedCommand = commands[command];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //No commands was found
            if(requestedCommand != null)
            {
                //populate flags
                //TODO: Implement
                //Run command
                requestedCommand.Execute(rawArgs);
            }
            else
            {
                //No command found, lets show available commands
                StringBuilder helpText = new StringBuilder();
                helpText.AppendLine("Command <" + command + "> not found, try one of these \nWrite <command> -help for more info\n\n");

                if (commands.Count == 0)
                {
                    helpText.AppendLine("!Error: No available commands");
                }
                foreach (KeyValuePair<string, ICommandArgument> CommandEntry in commands)
                {
                    helpText.Append(">");
                    helpText.AppendLine(CommandEntry.Value.Name);
                }
                Console.WriteLine(helpText.ToString());
            }
           
        }

    }
}
