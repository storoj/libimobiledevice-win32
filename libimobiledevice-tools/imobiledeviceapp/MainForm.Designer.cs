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
            System.Windows.Forms.Panel DeviceInfoSelectDevicePanel;
            System.Windows.Forms.Label DeviceInfoDeviceLabel;
            System.Windows.Forms.GroupBox DeviceInfoOptionsGroup;
            this.DeviceInfoGetInfoButton = new System.Windows.Forms.Button();
            this.DeviceInfoDeviceSelector = new System.Windows.Forms.ComboBox();
            this.DeviceInfoResult = new System.Windows.Forms.TextBox();
            this.WorkModes = new System.Windows.Forms.TabControl();
            this.DeviceInfoTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DeviceInfoLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeviceInfoDebugOption = new System.Windows.Forms.CheckBox();
            this.DeviceInfoSimpleOption = new System.Windows.Forms.CheckBox();
            this.DeviceInfoDomainName = new System.Windows.Forms.TextBox();
            this.DeviceInfoDomainLabel = new System.Windows.Forms.Label();
            this.DeviceInfoKeyLabel = new System.Windows.Forms.Label();
            this.DeviceInfoKey = new System.Windows.Forms.TextBox();
            this.DeviceInfoXmlOption = new System.Windows.Forms.CheckBox();
            DeviceInfoSelectDevicePanel = new System.Windows.Forms.Panel();
            DeviceInfoDeviceLabel = new System.Windows.Forms.Label();
            DeviceInfoOptionsGroup = new System.Windows.Forms.GroupBox();
            DeviceInfoSelectDevicePanel.SuspendLayout();
            this.WorkModes.SuspendLayout();
            this.DeviceInfoTab.SuspendLayout();
            this.DeviceInfoLayoutPanel.SuspendLayout();
            DeviceInfoOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceInfoSelectDevicePanel
            // 
            DeviceInfoSelectDevicePanel.Controls.Add(DeviceInfoOptionsGroup);
            DeviceInfoSelectDevicePanel.Controls.Add(this.DeviceInfoGetInfoButton);
            DeviceInfoSelectDevicePanel.Controls.Add(this.DeviceInfoDeviceSelector);
            DeviceInfoSelectDevicePanel.Controls.Add(DeviceInfoDeviceLabel);
            DeviceInfoSelectDevicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DeviceInfoSelectDevicePanel.Location = new System.Drawing.Point(3, 3);
            DeviceInfoSelectDevicePanel.Name = "DeviceInfoSelectDevicePanel";
            DeviceInfoSelectDevicePanel.Size = new System.Drawing.Size(740, 114);
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
            this.DeviceInfoDeviceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceInfoDeviceSelector.FormattingEnabled = true;
            this.DeviceInfoDeviceSelector.Location = new System.Drawing.Point(53, 3);
            this.DeviceInfoDeviceSelector.Name = "DeviceInfoDeviceSelector";
            this.DeviceInfoDeviceSelector.Size = new System.Drawing.Size(301, 21);
            this.DeviceInfoDeviceSelector.Sorted = true;
            this.DeviceInfoDeviceSelector.TabIndex = 1;
            // 
            // DeviceInfoDeviceLabel
            // 
            DeviceInfoDeviceLabel.AutoSize = true;
            DeviceInfoDeviceLabel.Location = new System.Drawing.Point(3, 6);
            DeviceInfoDeviceLabel.Name = "DeviceInfoDeviceLabel";
            DeviceInfoDeviceLabel.Size = new System.Drawing.Size(44, 13);
            DeviceInfoDeviceLabel.TabIndex = 0;
            DeviceInfoDeviceLabel.Text = "&Device:";
            // 
            // DeviceInfoResult
            // 
            this.DeviceInfoResult.BackColor = System.Drawing.Color.Black;
            this.DeviceInfoResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceInfoResult.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceInfoResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.DeviceInfoResult.Location = new System.Drawing.Point(3, 123);
            this.DeviceInfoResult.Multiline = true;
            this.DeviceInfoResult.Name = "DeviceInfoResult";
            this.DeviceInfoResult.ReadOnly = true;
            this.DeviceInfoResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DeviceInfoResult.Size = new System.Drawing.Size(740, 379);
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
            this.DeviceInfoTab.Controls.Add(this.DeviceInfoLayoutPanel);
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
            // DeviceInfoLayoutPanel
            // 
            this.DeviceInfoLayoutPanel.ColumnCount = 1;
            this.DeviceInfoLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DeviceInfoLayoutPanel.Controls.Add(DeviceInfoSelectDevicePanel, 0, 0);
            this.DeviceInfoLayoutPanel.Controls.Add(this.DeviceInfoResult, 0, 1);
            this.DeviceInfoLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceInfoLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.DeviceInfoLayoutPanel.Name = "DeviceInfoLayoutPanel";
            this.DeviceInfoLayoutPanel.RowCount = 2;
            this.DeviceInfoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.DeviceInfoLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DeviceInfoLayoutPanel.Size = new System.Drawing.Size(746, 505);
            this.DeviceInfoLayoutPanel.TabIndex = 0;
            // 
            // DeviceInfoOptionsGroup
            // 
            DeviceInfoOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoXmlOption);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoKeyLabel);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoKey);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoDomainLabel);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoDomainName);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoSimpleOption);
            DeviceInfoOptionsGroup.Controls.Add(this.DeviceInfoDebugOption);
            DeviceInfoOptionsGroup.Location = new System.Drawing.Point(6, 30);
            DeviceInfoOptionsGroup.Name = "DeviceInfoOptionsGroup";
            DeviceInfoOptionsGroup.Size = new System.Drawing.Size(731, 81);
            DeviceInfoOptionsGroup.TabIndex = 3;
            DeviceInfoOptionsGroup.TabStop = false;
            DeviceInfoOptionsGroup.Text = "&Options:";
            // 
            // DeviceInfoDebugOption
            // 
            this.DeviceInfoDebugOption.AutoSize = true;
            this.DeviceInfoDebugOption.Location = new System.Drawing.Point(6, 19);
            this.DeviceInfoDebugOption.Name = "DeviceInfoDebugOption";
            this.DeviceInfoDebugOption.Size = new System.Drawing.Size(58, 17);
            this.DeviceInfoDebugOption.TabIndex = 0;
            this.DeviceInfoDebugOption.Text = "D&ebug";
            this.DeviceInfoDebugOption.UseVisualStyleBackColor = true;
            // 
            // DeviceInfoSimpleOption
            // 
            this.DeviceInfoSimpleOption.AutoSize = true;
            this.DeviceInfoSimpleOption.Location = new System.Drawing.Point(6, 43);
            this.DeviceInfoSimpleOption.Name = "DeviceInfoSimpleOption";
            this.DeviceInfoSimpleOption.Size = new System.Drawing.Size(57, 17);
            this.DeviceInfoSimpleOption.TabIndex = 1;
            this.DeviceInfoSimpleOption.Text = "&Simple";
            this.DeviceInfoSimpleOption.UseVisualStyleBackColor = true;
            // 
            // DeviceInfoDomainName
            // 
            this.DeviceInfoDomainName.Location = new System.Drawing.Point(182, 17);
            this.DeviceInfoDomainName.Name = "DeviceInfoDomainName";
            this.DeviceInfoDomainName.Size = new System.Drawing.Size(247, 20);
            this.DeviceInfoDomainName.TabIndex = 3;
            // 
            // DeviceInfoDomainLabel
            // 
            this.DeviceInfoDomainLabel.AutoSize = true;
            this.DeviceInfoDomainLabel.Location = new System.Drawing.Point(127, 20);
            this.DeviceInfoDomainLabel.Name = "DeviceInfoDomainLabel";
            this.DeviceInfoDomainLabel.Size = new System.Drawing.Size(49, 13);
            this.DeviceInfoDomainLabel.TabIndex = 2;
            this.DeviceInfoDomainLabel.Text = "Do&main: ";
            // 
            // DeviceInfoKeyLabel
            // 
            this.DeviceInfoKeyLabel.AutoSize = true;
            this.DeviceInfoKeyLabel.Location = new System.Drawing.Point(127, 44);
            this.DeviceInfoKeyLabel.Name = "DeviceInfoKeyLabel";
            this.DeviceInfoKeyLabel.Size = new System.Drawing.Size(28, 13);
            this.DeviceInfoKeyLabel.TabIndex = 4;
            this.DeviceInfoKeyLabel.Text = "Ke&y:";
            // 
            // DeviceInfoKey
            // 
            this.DeviceInfoKey.Location = new System.Drawing.Point(182, 41);
            this.DeviceInfoKey.Name = "DeviceInfoKey";
            this.DeviceInfoKey.Size = new System.Drawing.Size(247, 20);
            this.DeviceInfoKey.TabIndex = 5;
            // 
            // DeviceInfoXmlOption
            // 
            this.DeviceInfoXmlOption.AutoSize = true;
            this.DeviceInfoXmlOption.Location = new System.Drawing.Point(516, 19);
            this.DeviceInfoXmlOption.Name = "DeviceInfoXmlOption";
            this.DeviceInfoXmlOption.Size = new System.Drawing.Size(48, 17);
            this.DeviceInfoXmlOption.TabIndex = 6;
            this.DeviceInfoXmlOption.Text = "&XML";
            this.DeviceInfoXmlOption.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.WorkModes);
            this.Name = "MainForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            DeviceInfoSelectDevicePanel.ResumeLayout(false);
            DeviceInfoSelectDevicePanel.PerformLayout();
            this.WorkModes.ResumeLayout(false);
            this.DeviceInfoTab.ResumeLayout(false);
            this.DeviceInfoLayoutPanel.ResumeLayout(false);
            this.DeviceInfoLayoutPanel.PerformLayout();
            DeviceInfoOptionsGroup.ResumeLayout(false);
            DeviceInfoOptionsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl WorkModes;
        private System.Windows.Forms.TabPage DeviceInfoTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button DeviceInfoGetInfoButton;
        private System.Windows.Forms.ComboBox DeviceInfoDeviceSelector;
        private System.Windows.Forms.TextBox DeviceInfoResult;
        private System.Windows.Forms.CheckBox DeviceInfoDebugOption;
        private System.Windows.Forms.TableLayoutPanel DeviceInfoLayoutPanel;
        private System.Windows.Forms.CheckBox DeviceInfoSimpleOption;
        private System.Windows.Forms.Label DeviceInfoDomainLabel;
        private System.Windows.Forms.TextBox DeviceInfoDomainName;
        private System.Windows.Forms.Label DeviceInfoKeyLabel;
        private System.Windows.Forms.TextBox DeviceInfoKey;
        private System.Windows.Forms.CheckBox DeviceInfoXmlOption;
    }
}

