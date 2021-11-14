using System;
using System.Collections.Generic;
using System.Globalization;

namespace Serial_Port_Temperature_Monitor.DataHelpers
{
    public static class DataHelper
    {
        public static List<SensorData> SensorOneData { get; set; } = new List<SensorData>();
        public static List<SensorData> SensorTwoData { get; set; } = new List<SensorData>();

        public static void ParseSerialData(List<string> data)
        {
            SensorOneData.Clear();
            SensorTwoData.Clear();
            // Data layout:
            // Sensor n,Temperature in Celsius,Time
            // Ex: Sensor 1,27.42,01.01.2021 19:22:51
            foreach (var line in data)
            {
                if (line.StartsWith("Sensor"))
                {
                    // Split sensor line
                    string[] splitLine = line.Split(',');

                    SensorData sensorData = new SensorData(splitLine[0].Replace("Sensor ", ""), splitLine[1], splitLine[2]);
                    if (sensorData.SensorId == 0)
                        SensorOneData.Add(sensorData);
                    if (sensorData.SensorId == 1)
                        SensorTwoData.Add(sensorData);
                }
            }
        }
    }

    public struct SensorData
    {
        public int SensorId { get; set; }
        public float Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public SensorData(int sensorId, float temperature, DateTime dateTime)
        {
            SensorId = sensorId;
            Temperature = temperature;
            DateTime = dateTime;
        }

        public SensorData(string sensorId, string temperature, string dateTimeString)
        {
            SensorId = int.Parse(sensorId);
            Temperature = float.Parse(temperature, CultureInfo.InvariantCulture);
            DateTime = DateTime.Parse(dateTimeString);
        }

        public string[] AsShortTimeStringArray()
        {
            return new[] { SensorId.ToString(), Temperature.ToString(), DateTime.ToShortTimeString() };
        }

        public string[] AsStringArray()
        {
            return new[] { SensorId.ToString(), Temperature.ToString(), DateTime.ToString() };
        }
    }
}
