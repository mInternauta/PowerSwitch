using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawerBackup.CommandLine;

namespace PowerSwitch.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PowerSwitch CLI Utility";
            Console.WriteLine("mInternauta 2016 - " + DateTime.Now.Year);

            Trace.Listeners.Add(new TextWriterTraceListener("PowerSwitch.log"));
            Trace.Listeners.Add(new ConsoleTraceListener( ));
            Trace.AutoFlush = true;

            OptionApplication app = new OptionApplication(new CLIOptions( ));
            Environment.Exit(app.Execute(args));
        }
    }
}
