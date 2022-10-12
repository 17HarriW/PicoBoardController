using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoBoardController
{
    class PicoBoard
    {
        // Source: https://twiki.cern.ch/twiki/pub/Sandbox/DaqSchoolExercise14/Picoboard_protocol.pdf
        public enum Sensor
        {
            RESISTANCE_D = 0,
            RESISTANCE_C = 1,
            RESISTANCE_B = 2,
            BUTTON = 3,
            RESISTANCE_A = 4,
            LIGHT = 5,
            SOUND = 6,
            SLIDER = 7
        }

        private int[] sensorValues = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        private byte[] buffer = new byte[18];

        SerialPort p = new SerialPort();

        public void Connect(string portName)
        {
            // Show all port names
            /*foreach(string portName in SerialPort.GetPortNames())
            {
                Console.WriteLine(portName);
            }*/
            p.PortName = portName;
            p.BaudRate = 38400;
            p.ReadTimeout = 10;

            p.Open();
        }

        public void Disconnect()
        {
            p.Close();
        }

        public int ReadSensor(int SensorNumber)
        {
            buffer[0] = 1;

            // Request data packet
            p.Write(buffer, 0, 1);

            // Receive date from picoboard
            int bytesRead = p.Read(buffer, 0, 1);
            bytesRead += p.Read(buffer, 0, 17);
            Console.WriteLine($"Read {bytesRead} bytes");

            return sensorValues[(int)SensorNumber];
        }

        public bool IsConnected;
    }
}
