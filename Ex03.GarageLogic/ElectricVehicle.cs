using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct ElectricVehicle
    {
             
        private readonly float r_MaxBatteryCapacity;
        private float m_BatteryLevel;
        public ElectricVehicle(float i_MaxBatteryCapacity)
        {
            r_MaxBatteryCapacity = i_MaxBatteryCapacity;
            m_BatteryLevel = 0;
        }

        public float BatteryCapacity
        {
            set {m_BatteryLevel = value;}
            get { return m_BatteryLevel; }
        }

        private void FuelUp(float i_amountToCharge)
        {
            if (m_BatteryLevel + i_amountToCharge > r_MaxBatteryCapacity)
            {
                //exception
            }
            
            m_BatteryLevel += i_amountToCharge;
        }
    }
}
