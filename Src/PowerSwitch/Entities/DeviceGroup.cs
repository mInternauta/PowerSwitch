using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSwitch.Entities
{
    /// <summary>
    /// Device Group
    /// </summary>
    public class DeviceGroup : BaseEntity
    {
        /// <summary>
        /// The device group is enabled?
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Name of the Group
        /// </summary>
        public string Name { get; set; }

           /// <summary>
        /// Username for all the Devices in the group
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for all the Devices in the group
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Platform for all the Devices in the group
        /// </summary>
        public DevicePlatform Platform { get; set; }
    }
}
