using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {

        private readonly float r_BatteryCapacityHours;
        private float m_BatteryLevel = 0;

        public float BatterLevel
        {
            get { return r_BatteryCapacityHours; }
            private set
            {
                try
                {
                    FrequantActions.EnterFloatValueInRange(ref m_BatteryLevel, value, "Battery", r_BatteryCapacityHours);
                    CurrentPowerPercentage = m_BatteryLevel / r_BatteryCapacityHours;
                }
                catch (ValueOutOfRangeException io_PassedBatteryCapacity)
                {
                    throw io_PassedBatteryCapacity;
                }
            }
        }

        public ElectricEngine(float i_BatteryCapacityHours)
        {
            r_BatteryCapacityHours = i_BatteryCapacityHours;
        }

        internal void ChargeBattery(float i_amountToCharge)
        {
            try
            {
                BatterLevel += i_amountToCharge;
            }
            catch(ValueOutOfRangeException io_FailedChargingBattery) 
            {
                throw io_FailedChargingBattery;
            }
        }

        internal override List<string> GetAttributesList()
        {
        }
    }
  
}
