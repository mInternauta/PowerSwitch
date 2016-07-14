using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerSwitch.Entities;
using PowerSwitch.Extensions;

namespace PowerSwitch.ConfigTool
{
    public partial class DeviceEditor : Form
    {
        public DeviceEditor(RemoteDevice current)
        {
            InitializeComponent( );
            this.Current = current;
        }
        public RemoteDevice Current { get; private set; }

        private void DeviceEditor_Load(object sender, EventArgs e)
        {
            // Load the Platforms //
            LoadPlatforms( );

            this.txtAddress.Text = Current.Address;
            this.txtName.Text = Current.Name;
            this.txtUsername.Text = Current.Username;
        }

        private void LoadPlatforms( )
        {
            var platforms = Enum.GetNames(typeof(DevicePlatform)).ToList( );
            cbPlatform.Items.Clear( );
            cbPlatform.Items.AddRange(platforms.ToArray( ));

            // 
            string cPlatform = Enum.GetName(typeof(DevicePlatform), Current.Platform);
            int index = platforms.IndexOf(cPlatform);
            cbPlatform.SelectedIndex = index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetPlatform( );
            Current.Address = this.txtAddress.Text;
            Current.Name = this.txtName.Text;
            Current.Username = this.txtUsername.Text;

            if(string.IsNullOrEmpty(this.txtPassword.Text) == false)
            {
               Current.SetPassword(this.txtPassword.Text);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void SetPlatform( )
        {
            if (cbPlatform.SelectedIndex >= 0)
            {
                string value = cbPlatform.SelectedItem as string;
                Current.Platform = (DevicePlatform) Enum.Parse(typeof(DevicePlatform), value);
            }
        }
    }
}
