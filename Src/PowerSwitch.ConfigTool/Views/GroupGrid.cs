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
    public partial class GroupGrid : UserControl
    {
        private GroupManager manager;

        public GroupGrid( )
        {
            InitializeComponent( );
        }

        public void Loads( )
        {
            this.manager = new GroupManager( );
            RefreshGroups( );
        }

        private void RefreshGroups( )
        {
            DataTable table = new DataTable( );
            table.Columns.Add("Id");
            table.Columns.Add("Name");

            foreach (DeviceGroup device in this.manager.All( ))
            {
                table.Rows.Add(device.Id, device.Name);
            }

            this.dtaGroups.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Edit(new DeviceGroup( ));
        }

        private void Edit(DeviceGroup group)
        {
            GroupEditor editor = new ConfigTool.GroupEditor(group);
            if (editor.ShowDialog( ) == DialogResult.OK)
            {
                manager.SaveOrUpdate(editor.Current);
                RefreshGroups( );
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeviceGroup group = GetSelected( );

            if (group != null)
            {
                manager.Remove(group);
                RefreshGroups( );
            }
        }

        private DeviceGroup GetSelected( )
        {
            DeviceGroup group = null;

            if (dtaGroups.SelectedRows.Count > 0)
            {
                var selectedRow = dtaGroups.SelectedRows[0];
                var selectedId = selectedRow.Cells[0].Value as string;
                group = manager.All( ).Where(p => p.Id == selectedId).First( );
            }

            return group;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DeviceGroup device = GetSelected( );

            if (device != null)
            {
                Edit(device);
                RefreshGroups( );
            }
        }
    }
}
