using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSwitch.ServiceCore.Windows
{
    public static class WindowsLogin
    {
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        private static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        public static bool IsValidateCredentials(string userName, string password, string domain)
        {
            IntPtr tokenHandler = IntPtr.Zero;
            bool isValid = LogonUser(userName, domain, password, 3, 0, ref tokenHandler);
            return isValid;
        }
    }
}
