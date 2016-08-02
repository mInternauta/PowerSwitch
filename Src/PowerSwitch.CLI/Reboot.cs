using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using DrawerBackup.CommandLine;
using PowerSwitch;
using PowerSwitch.Entities;

namespace PowerSwitch.CLI
{
    public class Reboot : AbstractPowerAction
    {
        [Option('a', "all", HelpText = "Reboot all configured devices")]
        public Boolean All { get; set; }

        [Option('d', "device", HelpText = "Reboot a configured device")]
        public string Device { get; set; }


        [Option('g', "group", HelpText = "Reboot all configured devices in the group")]
        public string Group { get; set; }


        public override int Execute( )
        {
            return Execute(All, Device, Group, (c) => {
                c.Reboot( );
            });
        }

        public override void Help( )
        {
            Trace.WriteLine("Avaliable options: ");
            Trace.WriteLine(" -a [-all]: Reboot all configured devices");
            Trace.WriteLine(" -d [-device]=[DEVICE NAME OR ID] : Reboot a configured device");
            Trace.WriteLine(" -g [-group]=[GROUP ID] : Reboot all configured devices in the group");
        }
    }
}
