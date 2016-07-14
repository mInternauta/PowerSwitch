using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch.Extensions
{
    public static class RemoteDeviceExtensions
    {
        public static string GetPassword(this RemoteDevice device)
        {
            return device.Password.Decrypt("powerswitch");
        }

        public static void SetPassword(this RemoteDevice device, string password)
        {
            device.Password = password.Encrypt("powerswitch");
        }

        public static SecureString GetSecurePassword(this RemoteDevice device)
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
