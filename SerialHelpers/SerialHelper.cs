using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Serial_Port_Temperature_Monitor.SerialHelpers
{
    public class SerialHelper
    {
        public string[] AvailablePorts { get; private set; }
        public SerialPort SerialPort { get; private set; }
        private bool _continueListening { get; set; }
        private List<string> _serialQueue { get; set; }
        private int _historyLimit { get; set; }

        private Thread _readThread { get; set; }
        private StringComparer _stringComparer = StringComparer.OrdinalIgnoreCase;

        public SerialHelper()
        {
            SerialPort = new SerialPort();
            _continueListening = false;
            _historyLimit = 10000; // Default cap for messages in serial message queue
            _readThread = new Thread(Read);
            // Set default values
            SerialPort.BaudRate = 9600;
            SetPortTimeouts(500, 500);
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

                    // Flush serial history once a manually set number of entries have been received
                    if (_serialQueue.Count >= _historyLimit)
                    {
                        _serialQueue.Clear();
                    }
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

        public void SetPortReadTimeOut(int readTimeout)
        {
            SerialPort.ReadTimeout = readTimeout;
        }

        public void SetPortWriteTimeout(int writeTimeout)
        {
            SerialPort.WriteTimeout = writeTimeout;
        }

        public void SetPortTimeouts(int readTimeout, int writeTimeout)
        {
            SetPortReadTimeOut(readTimeout);
            SetPortWriteTimeout(writeTimeout);
        }

        public void StartListening()
        {
            _continueListening = true;
            if (_readThread.IsAlive)
            {
                // Todo
                Trace.TraceInformation("Attempted to start an already existing thread.");

                return;
            }

            _readThread.Start();
        }

        public void StopListening()
        {
            _continueListening = false;
        }
    }
}
