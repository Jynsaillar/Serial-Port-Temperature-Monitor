using Serial_Port_Temperature_Monitor.SerialHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Port_Temperature_Monitor
{
    public partial class FormSerialMonitor : Form
    {
        private SerialHelper _serialHelper { get; set; }

        public FormSerialMonitor()
        {
            InitializeComponent();
        }

        private void LoadUiSettings()
        {
            comboBoxBaudRate.SelectedIndex = 6;
            DiscoverSerialPorts();
        }

        private void DiscoverSerialPorts()
        {
            comboBoxSerialPorts.Items.Clear();

            foreach (var port in _serialHelper.GetAvailablePorts())
            {
                comboBoxSerialPorts.Items.Add(port);
            }

            if (comboBoxSerialPorts.Items.Count > 0)
            {
                comboBoxSerialPorts.SelectedIndex = 0;
            }
        }

        public FormSerialMonitor(SerialHelper serialHelper) : this()
        {
            _serialHelper = serialHelper;
            LoadUiSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiscoverSerialPorts();
        }

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBaudRate.SelectedItem == null)
                return;

            _serialHelper.SetBaudRate(
                int.Parse(comboBoxBaudRate.SelectedItem.ToString()));
        }
    }
}
