using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Serial_Port_Temperature_Monitor.SerialHelpers
{
    public class SerialHelper
    {
        public string[] AvailablePorts { get; private set; }
        public SerialPort SerialPort { get; private set; }
        private bool _continueListening { get; set; }
        public bool Connected { get; set; }
        private ObservableCollection<string> _serialQueue;
        public ObservableCollection<string> SerialQueue => _serialQueue;

        public event NotifyCollectionChangedEventHandler MessageReceived
        {
            add
            {
                _serialQueue.CollectionChanged += value;
            }
            remove
            {
                this._serialQueue.CollectionChanged -= value;
            }
        }

        private int _historyLimit { get; set; }

        private Thread _readThread { get; set; }
        private StringComparer _stringComparer = StringComparer.OrdinalIgnoreCase;

        public SerialHelper()
        {
            _serialQueue = new ObservableCollection<string>();
            SerialPort = new SerialPort();
            _continueListening = false;
            _historyLimit = 10000; // Default cap for messages in serial message queue
            // Set default values
            SerialPort.BaudRate = 9600;
            SetPortTimeouts(500, 500);
            SerialPort.DtrEnable = true; // Forces restart on serial connect on devices like Arduino Uno, Mega 2560, ESP32 etc.
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
                // Abort if serial connection is interrupted, for example if the user removes the USB while the program is polling for serial data
                if (!SerialPort.IsOpen)
                {
                    Connected = false;
                    _continueListening = false;
                    continue;
                }
                try
                {
                    int bytesToRead = SerialPort.BytesToRead;

                    if (bytesToRead == 0)
                        continue;

                    /*

                    byte[] buffer = new byte[bytesToRead];
                    SerialPort.Read(buffer, 0, buffer.Length);

                    //
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesToRead);
                    Trace.TraceInformation("msg: " + message);
                    //
                    */

                    string message = SerialPort.ReadLine();
                    if (!string.IsNullOrWhiteSpace(message))
                        _serialQueue.Add(message.TrimEnd(Environment.NewLine.ToCharArray()) + "," + DateTime.Now + Environment.NewLine);

                    // Flush serial history once a manually set number of entries have been received
                    if (_serialQueue.Count >= _historyLimit)
                    {
                        _serialQueue.Clear();
                    }
                }
                catch (TimeoutException)
                {
                }
                catch (OperationCanceledException)
                {
                }
            }
        }

        public void Write(string message)
        {
            if (!TryOpenSerialPort())
                return;

            SerialPort.Write(message);
        }

        public bool SetPortName(string portName)
        {
            if (string.IsNullOrWhiteSpace(portName))
                return false;

            if (SerialPort.IsOpen)
                return false;

            if (SerialPort.GetPortNames().Any(item => _stringComparer.Equals(item, portName)))
            {
                SerialPort.PortName = portName;
                return true;
            }

            return false;
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

        private void CreateReadThread()
        {
            if (_readThread == null || !_readThread.IsAlive)
                _readThread = new Thread(Read);
        }

        public void StartListening()
        {
            if (!TryOpenSerialPort())
                return;

            CreateReadThread();

            Connected = true;
            _continueListening = true;

            _readThread.Start();
        }

        public void StopListening()
        {
            Connected = false;
            _continueListening = false;
            SerialPort.Close();
        }

        private bool TryOpenSerialPort()
        {
            if (!SerialPort.IsOpen)
            {
                try
                {
                    SerialPort.Open();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception thrown while opening port: "
                       + "\n  Type:    " + ex.GetType().Name
                       + "\n  Message: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        public void ClearHistory()
        {
            _serialQueue.Clear();
        }
    }
}
