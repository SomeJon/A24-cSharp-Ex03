using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {

        private readonly float r_BatteryCapacityHours;
        public ElectricEngine(float i_BatteryCapacityHours)
        {
            r_BatteryCapacityHours = i_BatteryCapacityHours;
        }

        private void ChargeBattery(float i_amountToCharge)
        {
            if (m_CurrentPowerPercentage + i_amountToCharge > r_BatteryCapacityHours)
            {
                //exception
            }

            m_CurrentPowerPercentage += i_amountToCharge;
        }

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "vehicle's current battery percentage" };
        }
    }
  
}
