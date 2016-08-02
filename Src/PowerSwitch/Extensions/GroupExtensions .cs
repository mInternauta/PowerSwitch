using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch.Extensions
{
    public static class GroupExtensions
    {
        public static string GetPassword(this DeviceGroup device)
        {
            return device.Password.Decrypt("powerswitch");
        }

        public static void SetPassword(this DeviceGroup device, string password)
        {
            device.Password = password.Encrypt("powerswitch");
        }

        public static SecureString GetSecurePassword(this DeviceGroup device)
        {
            SecureString sec = new SecureString();
            foreach (char item in device.GetPassword())
            {
                sec.AppendChar(item);
            }

            return sec;
        }
    }
}
