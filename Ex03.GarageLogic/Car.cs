using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        protected enum eColor
        {
            Blue,
            White,
            Red,
            Yellow
        }

        protected const byte k_CarWheelNum = 5;
        protected const byte k_CarMaxAirPressure = 30;
        protected eColor m_Color;
        protected byte m_NumOfDoors;
        Wheel[] m_Wheels = new Wheel[k_CarWheelNum];

        public Car(string i_LicensePlate) : base(i_LicensePlate)
        {
            for (int i = 0; i < k_CarWheelNum; i++) 
            {
                m_Wheels[i] = new Wheel(k_CarMaxAirPressure);
            }
        }

    }
}
