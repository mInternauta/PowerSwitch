﻿using System;
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
        private GroupManager groupManager;
        private List<string> platforms;

        public DeviceEditor(RemoteDevice current)
        {
            InitializeComponent( );
            this.Current = current;
            this.groupManager = new GroupManager( );
        }
        public RemoteDevice Current { get; private set; }

        private void DeviceEditor_Load(object sender, EventArgs e)
        {
            // Load the Platforms //
            LoadPlatforms( );

            // Load the Groups //
            LoadGroups( );

            this.txtAddress.Text = Current.Address;
            this.txtName.Text = Current.Name;
            this.txtUsername.Text = Current.Username;

            SetEnabled( );
        }

        private void LoadGroups( )
        {
            var groups = groupManager.All( ).Select(p => new Views.CbGroupItem(p));

            cbGroup.Items.Clear( );
            if (groups.Any( ))
            {
                var cGroupList = groups.ToList( );
                cbGroup.Items.AddRange(groups.ToArray( ));

                if (string.IsNullOrEmpty(Current.IDGroup) == false)
                {
                    var cGroup = cGroupList.Where(p => p.Group.Id == Current.IDGroup);
                    if (cGroup.Any( ))
                    {
                        int index = cGroupList.IndexOf(cGroup.First( ));
                        cbGroup.SelectedIndex = index;
                    }
                }
            }
        }

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

            Current.Address = this.txtAddress.Text;
            Current.Name = this.txtName.Text;
            Current.Username = this.txtUsername.Text;

            if(string.IsNullOrEmpty(this.txtPassword.Text) == false)
            {
               Current.SetPassword(this.txtPassword.Text);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void SetGroup( )
        {
            if(cbGroup.SelectedIndex >= 0)
            {
                Views.CbGroupItem selected = (Views.CbGroupItem) cbGroup.SelectedItem;
                Current.IDGroup = selected.Group.Id;
                this.txtUsername.Text = selected.Group.Username;
                this.txtPassword.Text = selected.Group.GetPassword();
                SetPlatformTo(selected.Group.Platform);
            }
        }

        private void SetPlatform( )
        {
            if (cbPlatform.SelectedIndex >= 0)
            {
                string value = cbPlatform.SelectedItem as string;
                Current.Platform = (DevicePlatform) Enum.Parse(typeof(DevicePlatform), value);
            }
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGroup( );
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
