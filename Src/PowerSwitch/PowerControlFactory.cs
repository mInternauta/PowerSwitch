using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch
{
    /// <summary>
    /// Factory for the power controls
    /// </summary>
    public class PowerControlFactory
    {
        private List<Type> powerControls;

        public PowerControlFactory( )
        {
            this.powerControls = new List<Type>( );

            // Register the Power Control Types //
            this.powerControls.Add(typeof(Windows.PsNoSslWindows));
            this.powerControls.Add(typeof(Windows.PsSslWindows));
            this.powerControls.Add(typeof(Windows.WinWmiPowerControl));
            this.powerControls.Add(typeof(Linux.UbuntuSshPowerControl));
            this.powerControls.Add(typeof(Linux.DebianSshPowerControl));
        }

        /// <summary>
        /// Fetch a instance of the power control for the remote device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public IPowerControl Create(RemoteDevice device)
        {
            IPowerControl powerControl = null;

            foreach (Type powerControlType in powerControls)
            {
                powerControl = Activator.CreateInstance(powerControlType) as IPowerControl;
                if(powerControl.CompatibleTo() == device.Platform)
                {
                    powerControl.Setup(device);
                    break;
                }
                else
                {
                    powerControl = null;
                }
            }

            return powerControl;
        }
    }
}
