using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;
using PowerSwitch.Extensions;

namespace PowerSwitch.Windows
{
    public class WinWmiPowerControl : IPowerControl
    {
        private ManagementObject OSObject;

        public override DevicePlatform CompatibleTo( )
        {
            return DevicePlatform.WindowsWmi;
        }

        public override void Reboot( )
        {
            Execute(6, "Power switch is rebooting the computer");
        }

        public override void Setup(RemoteDevice device)
        {
            ConnectionOptions options = new ConnectionOptions( );
            options.EnablePrivileges = true;

            options.SecurePassword = device.GetSecurePassword( );
            options.Username = device.Username;

            ManagementScope scope = new ManagementScope("\\\\" + device.Address + "\\root\\CIMV2", options);
            scope.Connect( );

            SelectQuery query = new SelectQuery("Win32_OperatingSystem");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(scope, query);

            this.OSObject = searcher.Get( ).OfType<ManagementObject>( ).First( );
        }

        public override void Shutdown( )
        {
            Execute(5, "Power switch is powering off the computer");
        }

        protected override string GetName( )
        {
            return "Windows WMI Power Control";
        }


        private void Execute(int flag, string message)
        {
            ManagementBaseObject inParams = OSObject.GetMethodParameters("Win32ShutdownTracker");
            inParams["Flags"] = flag;
            inParams["ReasonCode"] = 0;
            inParams["Timeout"] = 60;
            inParams["Comment"] = message;

            ManagementBaseObject outParams =
                OSObject.InvokeMethod("Win32ShutdownTracker", inParams, null);
            
            int returnValue = Convert.ToInt32(outParams["ReturnValue"]);
            if(returnValue != 0)
            {
                throw new OperationCanceledException("the execution failed, returned: " + returnValue);
            }
        }
    }
}
