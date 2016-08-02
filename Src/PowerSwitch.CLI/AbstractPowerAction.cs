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
        GroupManager groups = new GroupManager( );

        protected int Execute(Boolean All, String Device, String Group, Action<IPowerControl> action)
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

                if(string.IsNullOrEmpty(Group) == false)
                {
                    var groupSearch = groups.All( ).Where(p => p.Id.Contains(Group));

                    if (groupSearch.Any( ))
                    {
                        if (groupSearch.First( ).IsEnabled)
                        {
                            var search = devices.All( ).Where(p => p.IDGroup.Contains(Group));
                            foreach (RemoteDevice device in search)
                            {
                                ExecForDevice(factory, device, action);
                            }
                        }
                        else
                        {
                            Trace.WriteLine("The group is disabled!");
                        }
                    }
                    else
                    {
                        Trace.WriteLine("Cant find the group!");
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
                // Check if the group is disabled
                if(string.IsNullOrEmpty(device.IDGroup) == false)
                {
                    var search = groups.All( ).Where(p => p.Id == device.IDGroup);
                    if(search.Any())
                    {
                        if (search.First( ).IsEnabled == false)
                            throw new EntryPointNotFoundException("The group of the device is disabled");
                    }
                }


                if(device.IsEnabled == false)
                {
                    throw new EntryPointNotFoundException("The device is disabled");
                }


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
