using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawerBackup.CommandLine;
using PowerSwitch.Entities;

namespace PowerSwitch.CLI
{
    public abstract class AbstractPowerAction : AbstractOption
    {
        protected int Execute(Boolean All, String Device, Action<IPowerControl> action)
        {
            PowerControlFactory factory = new PowerControlFactory( );
            DeviceManager devices = new DeviceManager( );

            if (All)
            {
                foreach (RemoteDevice device in devices.All( ))
                {
                    ExecForDevice(factory, device, action);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Device) == false)
                {
                    var search = devices.All( ).Where(p => p.Id.Contains(Device) || p.Name.Contains(Device));
                    if (search.Any( ))
                    {
                        ExecForDevice(factory, search.First( ), action);
                    }
                    else
                    {
                        Trace.WriteLine("Cant find the device!");
                    }
                }
            }

            return 0;
        }

        private void ExecForDevice(PowerControlFactory factory, RemoteDevice device, Action<IPowerControl> action)
        {
            Trace.WriteLine("Trying to execute action in the device: " + device.Name);
            try
            {
                IPowerControl control = factory.Create(device);
                if (control != null)
                {
                    action(control);
                    Trace.WriteLine("Finished");
                }
                else
                {
                    throw new InvalidOperationException("Cant found the power control for the device");
                }
            }
            catch (Exception exp)
            {
                Trace.WriteLine("Cant execute action the device: " + exp.Message);
            }
        }
    }
}
