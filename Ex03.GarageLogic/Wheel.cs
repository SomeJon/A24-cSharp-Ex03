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

        internal Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }  
        internal void FillAir(float i_AirToAdd) 
        {
            if (m_AirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                //exception
            }

            m_AirPressure += i_AirToAdd;
        }

        internal List<string> GetAttributesList()
        {
            return new List<string> { "wheel's manufacturer", "wheel's air pressure" };
        }
    }
}
