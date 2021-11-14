
namespace Serial_Port_Temperature_Monitor
{
    partial class FormSerialMonitor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.buttonRefreshSerialPorts = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerialMonitorSend = new System.Windows.Forms.Button();
            this.textBoxSerialMonitorSend = new System.Windows.Forms.TextBox();
            this.richTextBoxSerialMonitor = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSerialPortConnect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonParseData = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRefreshSerialPorts
            // 
            this.buttonRefreshSerialPorts.Location = new System.Drawing.Point(136, 22);
            this.buttonRefreshSerialPorts.Name = "buttonRefreshSerialPorts";
            this.buttonRefreshSerialPorts.Size = new System.Drawing.Size(58, 23);
            this.buttonRefreshSerialPorts.TabIndex = 0;
            this.buttonRefreshSerialPorts.Text = "Refresh";
            this.buttonRefreshSerialPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshSerialPorts.Click += new System.EventHandler(this.buttonRefreshSerialPorts_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerialMonitorSend);
            this.groupBox1.Controls.Add(this.textBoxSerialMonitorSend);
            this.groupBox1.Controls.Add(this.richTextBoxSerialMonitor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 296);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Monitor";
            // 
            // buttonSerialMonitorSend
            // 
            this.buttonSerialMonitorSend.Location = new System.Drawing.Point(463, 267);
            this.buttonSerialMonitorSend.Name = "buttonSerialMonitorSend";
            this.buttonSerialMonitorSend.Size = new System.Drawing.Size(89, 23);
            this.buttonSerialMonitorSend.TabIndex = 2;
            this.buttonSerialMonitorSend.Text = "Send";
            this.buttonSerialMonitorSend.UseVisualStyleBackColor = true;
            this.buttonSerialMonitorSend.Click += new System.EventHandler(this.buttonSerialMonitorSend_Click);
            // 
            // textBoxSerialMonitorSend
            // 
            this.textBoxSerialMonitorSend.Location = new System.Drawing.Point(7, 267);
            this.textBoxSerialMonitorSend.Name = "textBoxSerialMonitorSend";
            this.textBoxSerialMonitorSend.Size = new System.Drawing.Size(450, 23);
            this.textBoxSerialMonitorSend.TabIndex = 1;
            // 
            // richTextBoxSerialMonitor
            // 
            this.richTextBoxSerialMonitor.Location = new System.Drawing.Point(7, 23);
            this.richTextBoxSerialMonitor.Name = "richTextBoxSerialMonitor";
            this.richTextBoxSerialMonitor.ReadOnly = true;
            this.richTextBoxSerialMonitor.Size = new System.Drawing.Size(545, 238);
            this.richTextBoxSerialMonitor.TabIndex = 0;
            this.richTextBoxSerialMonitor.Text = "";
            this.richTextBoxSerialMonitor.TextChanged += new System.EventHandler(this.richTextBoxSerialMonitor_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSerialPorts);
            this.groupBox2.Controls.Add(this.buttonRefreshSerialPorts);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 67);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Ports";
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(7, 23);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(123, 23);
            this.comboBoxSerialPorts.TabIndex = 1;
            this.comboBoxSerialPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPorts_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(576, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 404);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxBaudRate);
            this.groupBox3.Location = new System.Drawing.Point(3, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 58);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Baud Rate";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(7, 22);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(187, 23);
            this.comboBoxBaudRate.TabIndex = 2;
            this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSerialPortConnect);
            this.panel1.Location = new System.Drawing.Point(3, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 264);
            this.panel1.TabIndex = 4;
            // 
            // buttonSerialPortConnect
            // 
            this.buttonSerialPortConnect.Enabled = false;
            this.buttonSerialPortConnect.Location = new System.Drawing.Point(10, 232);
            this.buttonSerialPortConnect.Name = "buttonSerialPortConnect";
            this.buttonSerialPortConnect.Size = new System.Drawing.Size(187, 23);
            this.buttonSerialPortConnect.TabIndex = 0;
            this.buttonSerialPortConnect.Text = "Connect";
            this.buttonSerialPortConnect.UseVisualStyleBackColor = true;
            this.buttonSerialPortConnect.Click += new System.EventHandler(this.buttonSerialPortConnect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listView2);
            this.groupBox4.Controls.Add(this.buttonParseData);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(19, 314);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(551, 108);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Display";
            // 
            // buttonParseData
            // 
            this.buttonParseData.Location = new System.Drawing.Point(456, 79);
            this.buttonParseData.Name = "buttonParseData";
            this.buttonParseData.Size = new System.Drawing.Size(89, 23);
            this.buttonParseData.TabIndex = 1;
            this.buttonParseData.Text = "Parse Data";
            this.buttonParseData.UseVisualStyleBackColor = true;
            this.buttonParseData.Click += new System.EventHandler(this.buttonParseData_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView1.Location = new System.Drawing.Point(7, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(212, 79);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView2.Location = new System.Drawing.Point(225, 22);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(225, 79);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // FormSerialMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSerialMonitor";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefreshSerialPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.RichTextBox richTextBoxSerialMonitor;
        private System.Windows.Forms.TextBox textBoxSerialMonitorSend;
        private System.Windows.Forms.Button buttonSerialMonitorSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSerialPortConnect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonParseData;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
    }
}

