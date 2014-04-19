using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole
{
    public class CommandEnvironment
    {
        private Dictionary<string, object> CommandFlags;
        public CommandEnvironment()
        {
            CommandFlags = new Dictionary<string, object>();
        }
        public object GetFlag(string flag)
        {
            return CommandFlags[flag];
        }
        public void SetFlag(string flagName, object value)
        {
            try
            {
                CommandFlags.Add(flagName, value);
            }
            catch(ArgumentException ae)
            {
                //flag already set swallow
            }
        }
    }
}
