using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch.Windows
{
    public class PsSslWindows : WindowsPowerControl
    {
        public override DevicePlatform CompatibleTo( )
        {
            return DevicePlatform.WindowsSsl;
        }

        protected override int PowerShellPort( )
        {
            return 5986;
        }

        protected override bool PowerShellUseSsl( )
        {
            return true;
        }
    }
}
