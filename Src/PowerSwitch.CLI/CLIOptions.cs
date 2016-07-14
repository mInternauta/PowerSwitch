using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using DrawerBackup.CommandLine;

namespace PowerSwitch.CLI
{
    public class CLIOptions : IOptions
    {
        public string Name
        {
            get
            {
                return "PowerSwitch";
            }
        }

        [VerbOption("reboot", HelpText = "Reboot one or more devices")]
        public Reboot RebootVerb { get; set; }


        [VerbOption("poweroff", HelpText = "Power off one or more devices")]
        public Poweroff PoweroffVerb { get; set; }
    }
}
