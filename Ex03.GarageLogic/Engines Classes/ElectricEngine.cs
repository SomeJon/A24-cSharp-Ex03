using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {

        private readonly float r_BatteryCapacityHours;
        private float m_BatteryLevel = 0;

        public float BatteryLevel
        {
            get { return m_BatteryLevel; }
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

        public void ChargeBattery(float i_amountToCharge)
        {
            try
            {
                BatteryLevel += i_amountToCharge;
            }
            catch(ValueOutOfRangeException io_FailedChargingBattery) 
            {
                throw io_FailedChargingBattery;
            }
        }

        internal override List<string> GetAttributeNameList()
        {
            string attributeCharge = string.Format(@"Amount of charge of battery (max: {0})", r_BatteryCapacityHours);
            return new List<string> { attributeCharge };
        }

        internal override void EnterAtributes(List<string> i_Atributes)
        {
            const int k_NumOfExpectedAttributes = 1;
            float amountToCharge;

            try
            {
                if(!float.TryParse(i_Atributes[0], out amountToCharge))
                {
                    throw new FormatException("Electric Engine-Amount To Charge: Wrong format! expected battery charge to be a float!");
                }
                ChargeBattery(amountToCharge);
            }
            catch(Exception i_Exception) 
            { 
                throw i_Exception;
            }

            i_Atributes.RemoveRange(0, k_NumOfExpectedAttributes);
        }

        internal override List<string> GetAttributeValuesAsStringList()
        {
            string retValue = string.Format(@"{0}, {1:P2} of capacity", m_BatteryLevel, CurrentPowerPercentage);
            return new List<string> { retValue };
        }
    }
  
}
