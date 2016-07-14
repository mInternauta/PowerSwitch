# PowerSwitch

This small tool allows you to shutdown or reboot multiple machines at the same time.

![](https://s31.postimg.org/dzneeq1nv/Screenshot_17.png)

# How to?
Configure the devices using the Config Tool application, the types of plataforms are:

| Platform   | Description                                                                                        |
|------------|----------------------------------------------------------------------------------------------------|
| Windows    | Run the Reboot and Shutdown commands via Powershell without SSL on the default port.               |
| WindowsSsl | Run the Reboot and Shutdown commands via Powershell with SSL on the default port.                  |
| WindowsWmi | Run the Reboot and Shutdown commands via WMI, (Check [That Tutorial](https://www.poweradmin.com/help/faqs/how-to-enable-wmi-for-remote-access/) to configure the Remote Access of WMI) |
| UbuntuSsh  | Run the "shutdown" command to reboot and Shutdown a Linux machine via SSH.                         |

# How to run?
To perform the process just start the `psconsole` program with the following parameters:

psconsole [ACTION] [-all] [-d DEVICE_ID]

Actions:

| Action Name | Description                           |
|-------------|---------------------------------------|
| Reboot      | reboot one or more devices            |
| Poweroff    | shutdown and halt one or more devices |

Switches:
| Switch         | Description                                   |
|----------------|-----------------------------------------------|
| -all           | Execute the action for all configured devices |
| -d [DEVICE_ID] | Execute the action for a specified device     |

### Examples:

Rebooting all devices:
`psconsole reboot -all`

Rebooting a device by name:
`psconsole reboot -d "MyDevice"`

Rebooting a device by id:
`psconsole reboot -d XZA2Z5A5ZA5ZA`

## Thanks to
Newtonsoft for Json Library
Renci for the SSH.NET Library
gsscoder for the CommandLineParser Library

