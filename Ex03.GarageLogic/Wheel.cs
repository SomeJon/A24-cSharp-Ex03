using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }  
        public void InflatingWheel(float i_AirPressureToAdd) 
        {
            if (m_AirPressure + i_AirPressureToAdd > r_MaxAirPressure)
            {
                //exception
            }

            m_AirPressure += i_AirPressureToAdd;
        }
    }
}
