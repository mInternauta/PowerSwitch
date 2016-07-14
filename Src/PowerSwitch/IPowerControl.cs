using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch
{
    /// <summary>
    /// Interface to control the power of a remote device
    /// </summary>
    public abstract class IPowerControl
    {
        private TraceSource trace;

        /// <summary>
        /// Get the trace for the power control
        /// </summary>
        /// <returns></returns>
        public TraceSource GetTrace()
        {
            if (trace == null)
                this.trace = new TraceSource(this.GetName( ));

            return trace;
        }
        
        /// <summary>
        /// Get the compatible platform for the power control
        /// </summary>
        /// <returns></returns>
        public abstract DevicePlatform CompatibleTo( );

        /// <summary>
        /// Get name of the current power control
        /// </summary>
        /// <returns></returns>
        protected abstract string GetName( );

        /// <summary>
        /// Setup the power control to a device
        /// </summary>
        /// <param name="device"></param>
        public abstract void Setup(RemoteDevice device);

        /// <summary>
        /// Shutdown the remote device
        /// </summary>
        public abstract void Shutdown( );

        /// <summary>
        /// Reboots the remote device
        /// </summary>
        public abstract void Reboot( );
    }
}
