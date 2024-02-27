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

        internal List<string> GetAttributesList()
        {
            return new List<string> { "wheel's manufacturer", "wheel's air pressure" };
        }

        public override string ToString()
        {
            return string.Format("wheels manufacturer: {0},\ncurrent air pressure: {1}\n", m_Manufacturer, m_AirPressure);
        }
    }
}
