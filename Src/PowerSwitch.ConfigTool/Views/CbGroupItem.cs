using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerSwitch.Entities;

namespace PowerSwitch.ConfigTool.Views
{
    public class CbGroupItem
    {
        public CbGroupItem( DeviceGroup group)
        {
            this.Group = group;
        }
        public DeviceGroup Group { get; private set; }

        public override string ToString( )
        {
            return Group.Name;
        }
    }
}
