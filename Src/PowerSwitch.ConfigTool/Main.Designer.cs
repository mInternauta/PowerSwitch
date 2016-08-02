namespace PowerSwitch.ConfigTool
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tbConfigs = new System.Windows.Forms.TabControl();
            this.tbDevices = new System.Windows.Forms.TabPage();
            this.deviceGrid1 = new PowerSwitch.ConfigTool.Views.DeviceGrid();
            this.tbGroups = new System.Windows.Forms.TabPage();
            this.groupGrid1 = new PowerSwitch.ConfigTool.Views.GroupGrid();
            this.tbConfigs.SuspendLayout();
            this.tbDevices.SuspendLayout();
            this.tbGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConfigs
            // 
            this.tbConfigs.Controls.Add(this.tbDevices);
            this.tbConfigs.Controls.Add(this.tbGroups);
            this.tbConfigs.Location = new System.Drawing.Point(12, 12);
            this.tbConfigs.Name = "tbConfigs";
            this.tbConfigs.SelectedIndex = 0;
            this.tbConfigs.Size = new System.Drawing.Size(634, 415);
            this.tbConfigs.TabIndex = 0;
            // 
            // tbDevices
            // 
            this.tbDevices.Controls.Add(this.deviceGrid1);
            this.tbDevices.Location = new System.Drawing.Point(4, 22);
            this.tbDevices.Name = "tbDevices";
            this.tbDevices.Padding = new System.Windows.Forms.Padding(3);
            this.tbDevices.Size = new System.Drawing.Size(626, 389);
            this.tbDevices.TabIndex = 0;
            this.tbDevices.Text = "Devices";
            this.tbDevices.UseVisualStyleBackColor = true;
            // 
            // deviceGrid1
            // 
            this.deviceGrid1.Location = new System.Drawing.Point(6, 6);
            this.deviceGrid1.Name = "deviceGrid1";
            this.deviceGrid1.Size = new System.Drawing.Size(611, 383);
            this.deviceGrid1.TabIndex = 0;
            // 
            // tbGroups
            // 
            this.tbGroups.Controls.Add(this.groupGrid1);
            this.tbGroups.Location = new System.Drawing.Point(4, 22);
            this.tbGroups.Name = "tbGroups";
            this.tbGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tbGroups.Size = new System.Drawing.Size(626, 389);
            this.tbGroups.TabIndex = 1;
            this.tbGroups.Text = "Groups";
            this.tbGroups.UseVisualStyleBackColor = true;
            // 
            // groupGrid1
            // 
            this.groupGrid1.Location = new System.Drawing.Point(6, 3);
            this.groupGrid1.Name = "groupGrid1";
            this.groupGrid1.Size = new System.Drawing.Size(612, 386);
            this.groupGrid1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 436);
            this.Controls.Add(this.tbConfigs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerSwitch Configuration Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tbConfigs.ResumeLayout(false);
            this.tbDevices.ResumeLayout(false);
            this.tbGroups.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbConfigs;
        private System.Windows.Forms.TabPage tbDevices;
        private System.Windows.Forms.TabPage tbGroups;
        private Views.DeviceGrid deviceGrid1;
        private Views.GroupGrid groupGrid1;
    }
}