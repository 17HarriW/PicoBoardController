using System;
using System.Collections.Generic;
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

        public int[] sensorValues = new int[8] { 1,2,3,4,5,6,7,8};

        public void Connect()
        {

        }

        public void Disconnect()
        {

        }

        public int ReadSensor(int SensorNumber)
        {
            return sensorValues[(int)SensorNumber];
        }

        public bool IsConnected;
    }
}
