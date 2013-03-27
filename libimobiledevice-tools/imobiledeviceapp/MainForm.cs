using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iMobileDeviceApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void DeviceInfoGetInfoButton_Click(object sender, EventArgs e)
        {
            var deviceInfoProvider = new DeviceInfoProvider();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupTooltips();
        }

        private void SetupTooltips()
        {
            var toolTipsControlsPairs = new Dictionary<Control, string> {
                { DeviceInfoDebugOption, "Enable communication debugging." },
                { DeviceInfoSimpleOption, "Use a simple connection to avoid auto-pairing with the device." },
                { DeviceInfoDomainLabel, "Set domain of query to Text Field value. Leave empty for None." },
                { DeviceInfoDomainName, "Set domain of query to this value. Leave empty for None." },
                { DeviceInfoKeyLabel, "Only query a key specified in the Text Field. Leave empty for All keys." },
                { DeviceInfoKey, "Only query a key specified in this Text Field. Leave empty for All keys." },
                { DeviceInfoXmlOption, "Output information as XML plist instead of key/value pairs." }
            };

            foreach (var pair in toolTipsControlsPairs)
            {
                new ToolTip().SetToolTip(pair.Key, pair.Value);
            }
        }
    }
}
