namespace PowerSwitch.Entities
{
    /// <summary>
    /// The description of a remote device
    /// </summary>
    public class RemoteDevice : BaseEntity
    {
        /// <summary>
        /// Name of the Device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address of the Device
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Username of the Device
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password of the Device
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Platform of the Device
        /// </summary>
        public DevicePlatform Platform { get; set; }
    }
}