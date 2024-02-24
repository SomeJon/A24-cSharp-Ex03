using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        protected enum eLicenseType
        {
            A1,
            A2,
            AB,
            B2
        }

        protected const byte k_MotorcycleWheelNum = 2;
        protected const byte k_MotorcycleMaxAirPressure = 29;
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacity;
        Wheel[] m_Wheels = new Wheel[k_MotorcycleWheelNum];
        public Motorcycle(string i_LicensePlate) : base(i_LicensePlate)
        {
            for (int i = 0; i < k_MotorcycleWheelNum; i++)
            {
                m_Wheels[i] = new Wheel(k_MotorcycleMaxAirPressure);
            }
        }
    }
}
