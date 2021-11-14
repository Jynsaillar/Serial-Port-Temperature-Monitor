using CsvHelper;
using Serial_Port_Temperature_Monitor.DataHelpers;
using Serial_Port_Temperature_Monitor.SerialHelpers;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace Serial_Port_Temperature_Monitor
{
    public partial class FormSerialMonitor : Form
    {
        private SerialHelper _serialHelper { get; set; }
        private System.Timers.Timer LoggingTimer { get; set; }

        public FormSerialMonitor()
        {
            InitializeComponent();
        }

        public FormSerialMonitor(SerialHelper serialHelper) : this()
        {
            _serialHelper = serialHelper;
            _serialHelper.MessageReceived += _serialHelper_MessageReceived;
            LoadUiSettings();
            SetupLoggingTimer();
        }

        private void _serialHelper_MessageReceived(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateSerialMonitor();
        }

        private delegate void UpdateSerialMonitorCallback();

        private void UpdateSerialMonitor()
        {
            if (richTextBoxSerialMonitor.InvokeRequired)
            {
                UpdateSerialMonitorCallback updateSerialMonitorCallback = new UpdateSerialMonitorCallback(UpdateSerialMonitor);
                this.Invoke(updateSerialMonitorCallback, new object[] { });
            }
            else
            {
                richTextBoxSerialMonitor.Lines = _serialHelper.SerialQueue.ToArray();
            }
        }

        private void SetupLoggingTimer()
        {
            LoggingTimer = new System.Timers.Timer();
            LoggingTimer.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
            LoggingTimer.Elapsed += LoggingTimer_Elapsed;
        }

        private void LoggingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LogToFile();
        }

        private void LogToFile()
        {
            // Populate Sensor1/Sensor2 data in DataHelper
            DataHelper.ParseSerialData(_serialHelper.SerialQueue.ToList());
            //todo
            using (var writer = new StreamWriter("sensor1.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(DataHelper.SensorOneData);
            }

            using (var writer = new StreamWriter("sensor2.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(DataHelper.SensorTwoData);
            }
        }

        private void LoadUiSettings()
        {
            comboBoxBaudRate.SelectedIndex = 6;
            GenerateListView();
            DiscoverSerialPorts();
        }

        private void GenerateListView()
        {
            listView1.Columns.Add("Sensor");
            listView1.Columns.Add("Temperature");
            listView1.Columns.Add("Time");
            listView1.View = View.Details;

            listView2.Columns.Add("Sensor");
            listView2.Columns.Add("Temperature");
            listView2.Columns.Add("Time");
            listView2.View = View.Details;
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

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBaudRate.SelectedItem == null)
                return;

            _serialHelper.SetBaudRate(
                int.Parse(comboBoxBaudRate.SelectedItem.ToString()));
        }

        private void buttonSerialMonitorSend_Click(object sender, EventArgs e)
        {
            FlushPromptAndSendSerial();
        }

        private void FlushPromptAndSendSerial()
        {
            if (string.IsNullOrWhiteSpace(textBoxSerialMonitorSend.Text))
                return;

            _serialHelper.Write(textBoxSerialMonitorSend.Text);

            textBoxSerialMonitorSend.Clear();
        }

        private void buttonSerialPortConnect_Click(object sender, EventArgs e)
        {
            if (!_serialHelper.Connected)
            {
                richTextBoxSerialMonitor.Clear();
                ConnectToSerialPort();
                (sender as Button).Text = "Disconnect";
            }
            else
            {
                DisconnectFromSerialPort();
                (sender as Button).Text = "Connect";
            }
        }

        private void ConnectToSerialPort()
        {
            _serialHelper.StartListening();
            LoggingTimer.Start();
        }

        private void DisconnectFromSerialPort()
        {
            _serialHelper.StopListening();
            LoggingTimer.Stop();
        }

        private void buttonRefreshSerialPorts_Click(object sender, EventArgs e)
        {
            DiscoverSerialPorts();
        }

        private void comboBoxSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buttonSerialPortConnect.Enabled)
            {
                // Disable connect button in case the selected port is invalid so the user can only try to connect if there's a valid port selected
                buttonSerialPortConnect.Enabled = false;
            }

            if (comboBoxSerialPorts.SelectedItem == null)
                return;

            bool portSetSuccessfully = _serialHelper.SetPortName(comboBoxSerialPorts.SelectedItem.ToString());

            if (portSetSuccessfully)
            {
                buttonSerialPortConnect.Enabled = true;
            }
        }

        private void richTextBoxSerialMonitor_TextChanged(object sender, EventArgs e)
        {
            richTextBoxSerialMonitor.SelectionStart = richTextBoxSerialMonitor.Text.Length;
            richTextBoxSerialMonitor.ScrollToCaret();
        }

        private void buttonParseData_Click(object sender, EventArgs e)
        {
            ParseData();
        }

        private void ParseData()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();

            DataHelper.ParseSerialData(_serialHelper.SerialQueue.ToList());

            foreach (var sensorData in DataHelper.SensorOneData)
            {
                ListViewItem lvi = new ListViewItem(sensorData.AsStringArray());
                listView1.Items.Add(lvi);
            }

            foreach (var sensorData in DataHelper.SensorTwoData)
            {
                ListViewItem lvi = new ListViewItem(sensorData.AsStringArray());
                listView2.Items.Add(lvi);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
