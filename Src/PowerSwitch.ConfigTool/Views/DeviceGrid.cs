using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerSwitch.Entities;

namespace PowerSwitch.ConfigTool.Views
{
    public partial class DeviceGrid : UserControl
    {
        private DeviceManager manager;

        public DeviceGrid( )
        {
            InitializeComponent( );
        }

        public void Loads()
        {
            this.manager = new DeviceManager( );
            RefreshDevices( );
        }

        private void RefreshDevices( )
        {
            DataTable table = new DataTable( );
            table.Columns.Add("Id");
            table.Columns.Add("Name");

            foreach (RemoteDevice device in this.manager.All( ))
            {
                table.Rows.Add(device.Id, device.Name);
            }

            this.dtaDevices.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Edit(new RemoteDevice( ));
        }

        private void Edit(RemoteDevice remoteDevice)
        {
            DeviceEditor editor = new ConfigTool.DeviceEditor(remoteDevice);
            if (editor.ShowDialog( ) == DialogResult.OK)
            {
                manager.SaveOrUpdate(editor.Current);
                RefreshDevices( );
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoteDevice device = GetSelected( );

            if (device != null)
            {
                manager.Remove(device);
                RefreshDevices( );
            }
        }

        private RemoteDevice GetSelected( )
        {
            RemoteDevice device = null;

            if (dtaDevices.SelectedRows.Count > 0)
            {
                var selectedRow = dtaDevices.SelectedRows[0];
                var selectedId = selectedRow.Cells[0].Value as string;
                device = manager.All( ).Where(p => p.Id == selectedId).First( );
            }

            return device;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RemoteDevice device = GetSelected( );

            if (device != null)
            {
                Edit(device);
                RefreshDevices( );
            }
        }
    }
}
