using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;
using PowerSwitch.Extensions;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace PowerSwitch.Linux
{
    public abstract class SshPowerControl : IPowerControl
    {
        private SshClient client;
        
        public override void Reboot( )
        {
            using (var cmd = client.CreateCommand(GetRebootCmd()))
            {
                ExecuteCommand(cmd);
            }
        }

        private void ExecuteCommand(SshCommand cmd)
        {
            try
            {
                cmd.Execute( );
                if (cmd.ExitStatus != 0)
                {
                    throw new InvalidOperationException("Action failed in the host: " + cmd.Error);
                }
            }
            catch (SshConnectionException exp)
            {
                GetTrace( ).TraceInformation("Maybe the computer executed the action, " + exp.Message);
            }
        }

        protected abstract string GetShutdownCmd( );
        protected abstract string GetRebootCmd( );

        public override void Setup(RemoteDevice device)
        {
            ConnectionInfo connInfo = new ConnectionInfo(device.Address, 22, device.Username,
                new PasswordAuthenticationMethod(device.Username, device.GetPassword( )));
            

            this.client = new SshClient(connInfo);
            this.client.Connect( );
        }

        public override void Shutdown( )
        {
            using (var cmd = client.CreateCommand(GetShutdownCmd()))
            {
                ExecuteCommand(cmd);
            }
        }

        protected override string GetName( )
        {
            return "Ssh Power Control";
        }
    }
}
