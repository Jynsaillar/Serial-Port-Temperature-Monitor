using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Linq;

namespace Serial_Port_Temperature_Monitor.SerialHelpers
{
    public class SerialHelper
    {
        public string[] AvailablePorts { get; private set; }
        public SerialPort SerialPort { get; private set; }
        private bool _continueListening { get; set; }
        private List<string> _serialQueue { get; set; }

        private Thread _readThread { get; set; }
        private StringComparer _stringComparer = StringComparer.OrdinalIgnoreCase;

        public SerialHelper()
        {
            SerialPort = new SerialPort();
            _continueListening = false;
            _readThread = new Thread(Read);
            // Set default values
            SerialPort.BaudRate = 9600;
        }

        public string[] GetAvailablePorts()
        {
            AvailablePorts = SerialPort.GetPortNames();
            return AvailablePorts;
        }

        private void Read()
        {
            while (_continueListening)
            {
                try
                {
                    string message = SerialPort.ReadLine();
                    _serialQueue.Add(message);
                }
                catch (TimeoutException)
                {
                }
            }
        }

        public void SetPortName(string portName)
        {
            if (string.IsNullOrWhiteSpace(portName))
                return;

            if (SerialPort.GetPortNames().Any(item => _stringComparer.Equals(item, portName)))
            {
                SerialPort.PortName = portName;
            }
        }

        public void SetBaudRate(int baudRate)
        {
            SerialPort.BaudRate = baudRate;
        }

        public void SetPortParity(Parity parity)
        {
            SerialPort.Parity = parity;
        }

        public void SetPortDataBits(int dataBits)
        {
            SerialPort.DataBits = dataBits;
        }

        public void SetPortStopBits(StopBits stopBits)
        {
            SerialPort.StopBits = stopBits;
        }

        public void SetPortHandshake(Handshake handshake)
        {
            SerialPort.Handshake = handshake;
        }
    }
}
