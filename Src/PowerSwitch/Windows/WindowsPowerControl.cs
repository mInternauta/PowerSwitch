using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;
using PowerSwitch.Extensions;

namespace PowerSwitch.Windows
{
    public abstract class WindowsPowerControl : IPowerControl
    {
        private WSManConnectionInfo connectionInfo;
        private PSCredential credentials;

        public override void Reboot( )
        {
            Execute("Restart-Computer");
        }

        public override void Setup(RemoteDevice device)
        {
            GetTrace( ).TraceInformation("Configuring the device: " + device.Name);

            this.credentials = new PSCredential(device.Username, device.GetSecurePassword());
            string shellUri = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
            this.connectionInfo = new WSManConnectionInfo(PowerShellUseSsl(), device.Address, PowerShellPort(), "/wsman", shellUri, credentials);
        }

        public override void Shutdown( )
        {
            Execute("Stop-Computer");
        }

        protected override string GetName( )
        {
            return "Windows Power Control";
        }

        private void Execute(string cmd)
        {
            using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
            {
                runspace.Open( );
                Pipeline pipeline = runspace.CreatePipeline(cmd);
                var results = pipeline.Invoke( );
            }
        }



        protected abstract bool PowerShellUseSsl( );
        protected abstract int PowerShellPort( );
    }
}
