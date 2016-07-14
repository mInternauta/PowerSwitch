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
    public class Poweroff : AbstractPowerAction
    {
        [Option('a', "all", HelpText = "Power off all configured devices")]
        public Boolean All { get; set; }

        [Option('d', "device", HelpText = "Power off a configured device")]
        public string Device { get; set; }


        public override int Execute( )
        {
            return Execute(All, Device, (c) => {
                c.Shutdown( );
            });
        }

        public override void Help( )
        {
            Trace.WriteLine("Avaliable options: ");
            Trace.WriteLine(" -a [-all]: Power off all configured devices");
            Trace.WriteLine(" -d [-device]=[DEVICE NAME OR ID] : Power off a configure device");
        }
    }
}
