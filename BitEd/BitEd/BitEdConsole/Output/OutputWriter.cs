using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdConsole.Output
{
    internal class OutputWriter
    {
        bool verbose;
        string logFile;
        IOutputStream mainStream;

        public OutputWriter(CommandEnvironment environment)
        {
            //Check flags
            verbose = (bool)environment.GetFlag("v");
            if(environment.GetFlag("l")!=null)
            {
                //instaciate file output stream
                mainStream = new ConsoleOutStream();
                logFile = (string)environment.GetFlag("l");
            }
            else
            {
                mainStream = new ConsoleOutStream();
            }
        }
        public void Write(string text)
        {
             mainStream.WriteLine(text);
        }
        public void WriteVerbose(string text)
        {
            if(verbose)
            {
                mainStream.WriteLine(text);
            }
        }
    }
}
