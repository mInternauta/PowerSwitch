using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;
using PowerSwitch.Extensions;
using Renci.SshNet;

namespace PowerSwitch.Linux
{
    public class DebianSshPowerControl : SshPowerControl
    {
        public override DevicePlatform CompatibleTo( )
        {
            return DevicePlatform.DebianSsh;
        }

        protected override string GetRebootCmd( )
        {
            return "sudo shutdown -r +1 \"Power Switch is rebooting the system\"";
        }

        protected override string GetShutdownCmd( )
        {
            return "sudo shutdown -h +1 \"Power Switch is rebooting the system\"";
        }
    }
}
