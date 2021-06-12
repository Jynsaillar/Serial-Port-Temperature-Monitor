using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Serial_Port_Temperature_Monitor.SerialHelpers
{
    public class SerialHelper
    {
        public string[] AvailablePorts { get; private set; }

        private
        SerialHelper()
        {
        }

        public string[] GetAvailablePorts()
        {
            AvailablePorts = SerialPort.GetPortNames();
            return AvailablePorts;
        }
    }
}
