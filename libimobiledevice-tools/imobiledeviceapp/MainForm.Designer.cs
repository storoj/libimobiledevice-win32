namespace iMobileDeviceApp
{
    partial class MainForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.FlowLayoutPanel DeviceInfoLayoutPanel;
            System.Windows.Forms.Panel DeviceInfoSelectDevicePanel;
            System.Windows.Forms.Label Device;
            this.DeviceInfoGetInfoButton = new System.Windows.Forms.Button();
            this.DeviceInfoDeviceSelector = new System.Windows.Forms.ComboBox();
            this.DeviceInfoResult = new System.Windows.Forms.TextBox();
            this.WorkModes = new System.Windows.Forms.TabControl();
            this.DeviceInfoTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            DeviceInfoLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            DeviceInfoSelectDevicePanel = new System.Windows.Forms.Panel();
            Device = new System.Windows.Forms.Label();
            DeviceInfoLayoutPanel.SuspendLayout();
            DeviceInfoSelectDevicePanel.SuspendLayout();
            this.WorkModes.SuspendLayout();
            this.DeviceInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceInfoLayoutPanel
            // 
            DeviceInfoLayoutPanel.Controls.Add(DeviceInfoSelectDevicePanel);
            DeviceInfoLayoutPanel.Controls.Add(this.DeviceInfoResult);
            DeviceInfoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DeviceInfoLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            DeviceInfoLayoutPanel.Location = new System.Drawing.Point(3, 3);
            DeviceInfoLayoutPanel.Name = "DeviceInfoLayoutPanel";
            DeviceInfoLayoutPanel.Size = new System.Drawing.Size(746, 505);
            DeviceInfoLayoutPanel.TabIndex = 0;
            // 
            // DeviceInfoSelectDevicePanel
            // 
            DeviceInfoSelectDevicePanel.Controls.Add(this.DeviceInfoGetInfoButton);
            DeviceInfoSelectDevicePanel.Controls.Add(this.DeviceInfoDeviceSelector);
            DeviceInfoSelectDevicePanel.Controls.Add(Device);
            DeviceInfoSelectDevicePanel.Location = new System.Drawing.Point(3, 3);
            DeviceInfoSelectDevicePanel.Name = "DeviceInfoSelectDevicePanel";
            DeviceInfoSelectDevicePanel.Size = new System.Drawing.Size(740, 32);
            DeviceInfoSelectDevicePanel.TabIndex = 0;
            // 
            // DeviceInfoGetInfoButton
            // 
            this.DeviceInfoGetInfoButton.Location = new System.Drawing.Point(360, 3);
            this.DeviceInfoGetInfoButton.Name = "DeviceInfoGetInfoButton";
            this.DeviceInfoGetInfoButton.Size = new System.Drawing.Size(75, 21);
            this.DeviceInfoGetInfoButton.TabIndex = 2;
            this.DeviceInfoGetInfoButton.Text = "&Get Info";
            this.DeviceInfoGetInfoButton.UseVisualStyleBackColor = true;
            this.DeviceInfoGetInfoButton.Click += new System.EventHandler(this.DeviceInfoGetInfoButton_Click);
            // 
            // DeviceInfoDeviceSelector
            // 
            this.DeviceInfoDeviceSelector.FormattingEnabled = true;
            this.DeviceInfoDeviceSelector.Location = new System.Drawing.Point(53, 3);
            this.DeviceInfoDeviceSelector.Name = "DeviceInfoDeviceSelector";
            this.DeviceInfoDeviceSelector.Size = new System.Drawing.Size(301, 21);
            this.DeviceInfoDeviceSelector.TabIndex = 1;
            // 
            // Device
            // 
            Device.AutoSize = true;
            Device.Location = new System.Drawing.Point(3, 6);
            Device.Name = "Device";
            Device.Size = new System.Drawing.Size(44, 13);
            Device.TabIndex = 0;
            Device.Text = "&Device:";
            // 
            // DeviceInfoResult
            // 
            this.DeviceInfoResult.BackColor = System.Drawing.Color.Black;
            this.DeviceInfoResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceInfoResult.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceInfoResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.DeviceInfoResult.Location = new System.Drawing.Point(3, 41);
            this.DeviceInfoResult.Multiline = true;
            this.DeviceInfoResult.Name = "DeviceInfoResult";
            this.DeviceInfoResult.ReadOnly = true;
            this.DeviceInfoResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DeviceInfoResult.Size = new System.Drawing.Size(740, 461);
            this.DeviceInfoResult.TabIndex = 1;
            this.DeviceInfoResult.Text = "This is some text";
            // 
            // WorkModes
            // 
            this.WorkModes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkModes.Controls.Add(this.DeviceInfoTab);
            this.WorkModes.Controls.Add(this.tabPage2);
            this.WorkModes.Location = new System.Drawing.Point(12, 12);
            this.WorkModes.Name = "WorkModes";
            this.WorkModes.SelectedIndex = 0;
            this.WorkModes.Size = new System.Drawing.Size(760, 537);
            this.WorkModes.TabIndex = 0;
            // 
            // DeviceInfoTab
            // 
            this.DeviceInfoTab.Controls.Add(DeviceInfoLayoutPanel);
            this.DeviceInfoTab.Location = new System.Drawing.Point(4, 22);
            this.DeviceInfoTab.Name = "DeviceInfoTab";
            this.DeviceInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.DeviceInfoTab.Size = new System.Drawing.Size(752, 511);
            this.DeviceInfoTab.TabIndex = 0;
            this.DeviceInfoTab.Text = "Device Info";
            this.DeviceInfoTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.WorkModes);
            this.Name = "MainForm";
            this.Text = " ";
            DeviceInfoLayoutPanel.ResumeLayout(false);
            DeviceInfoLayoutPanel.PerformLayout();
            DeviceInfoSelectDevicePanel.ResumeLayout(false);
            DeviceInfoSelectDevicePanel.PerformLayout();
            this.WorkModes.ResumeLayout(false);
            this.DeviceInfoTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl WorkModes;
        private System.Windows.Forms.TabPage DeviceInfoTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button DeviceInfoGetInfoButton;
        private System.Windows.Forms.ComboBox DeviceInfoDeviceSelector;
        private System.Windows.Forms.TextBox DeviceInfoResult;
    }
}

