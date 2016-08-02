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
    public partial class GroupEditor : Form
    {
        private List<string> platforms;

        public GroupEditor(DeviceGroup current)
        {
            InitializeComponent( );
            this.Current = current;
        }
        public DeviceGroup Current { get; private set; }

        private void LoadPlatforms( )
        {
            this.platforms = Enum.GetNames(typeof(DevicePlatform)).ToList( );
            cbPlatform.Items.Clear( );
            cbPlatform.Items.AddRange(platforms.ToArray( ));

            // 
            DevicePlatform setPlatformTo = Current.Platform;
            SetPlatformTo(setPlatformTo);
        }

        private void SetPlatformTo(DevicePlatform setPlatformTo)
        {
            string cPlatform = Enum.GetName(typeof(DevicePlatform), setPlatformTo);
            int index = platforms.IndexOf(cPlatform);
            cbPlatform.SelectedIndex = index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetPlatform( );
            
            Current.Name = this.txtName.Text;
            Current.Username = this.txtUsername.Text;

            if (string.IsNullOrEmpty(this.txtPassword.Text) == false)
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

        private void GroupEditor_Load(object sender, EventArgs e)
        {

            // Load the Platforms //
            LoadPlatforms( );

            this.txtName.Text = Current.Name;
            this.txtUsername.Text = Current.Username;

            SetEnabled( );
        }

        private void SetEnabled( )
        {
            if (this.Current.IsEnabled)
            {
                btnEnable.Text = "Enabled";
                btnEnable.BackColor = Color.ForestGreen;
            }
            else
            {
                btnEnable.Text = "Disabled";
                btnEnable.BackColor = Color.Firebrick;
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            this.Current.IsEnabled = !this.Current.IsEnabled;
            SetEnabled( );
        }
    }
}
