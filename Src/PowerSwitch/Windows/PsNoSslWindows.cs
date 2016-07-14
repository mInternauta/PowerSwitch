using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch.Windows
{
    public class PsNoSslWindows : WindowsPowerControl
    {
        public override DevicePlatform CompatibleTo( )
        {
            return DevicePlatform.Windows;
        }

        protected override int PowerShellPort( )
        {
            return 5985;
        }

        protected override bool PowerShellUseSsl( )
        {
            return false;
        }
    }
}
