using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private readonly float r_TankCapacityLiters;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuel = 0;

        public float CurrentFuel
        {
            get { return m_CurrentFuel; }
            private set 
            {
                try
                {
                    FrequantActions.EnterFloatValueInRange(ref m_CurrentFuel, value, "Fuel", r_TankCapacityLiters);
                    CurrentPowerPercentage = m_CurrentFuel / r_TankCapacityLiters;
                }
                catch (ValueOutOfRangeException io_PassedFuelCapacity)
                {
                    throw io_PassedFuelCapacity;
                }
            }
        }

        public FuelEngine(eFuelType i_FuelType, float i_TankCapacityLiters)
        {
            r_FuelType = i_FuelType;
            r_TankCapacityLiters = i_TankCapacityLiters;
        }

        public void FillFuelTank(float i_AmountOfFuel, eFuelType i_EnteredFuelType)
        {
            try
            {
                if(i_EnteredFuelType != r_FuelType)
                {
                    throw new ArgumentException("Entered wrong fuel type!");
                }

                CurrentFuel += i_AmountOfFuel;
            }
            catch (ValueOutOfRangeException io_FailedFillingFuel)
            {
                throw io_FailedFillingFuel;
            }
        }

        internal override List<string> GetAttributeNameList()
        {
            string attributeFuel = string.Format(@"Amount of fuel, expected fuel to match engine (max: {0})", r_TankCapacityLiters);
            return new List<string> { attributeFuel };
        }

        internal override void EnterAtributes(List<string> i_Atributes)
        {
            const int k_NumOfExpectedAttributes = 1;
            float amountToFill;

            try
            {
                if (!float.TryParse(i_Atributes[0], out amountToFill))
                {
                    throw new FormatException("Fuel Engine-Amount To Fill: Wrong format! expected battery charge to be a float!");
                }
                FillFuelTank(amountToFill, r_FuelType);
            }
            catch (Exception i_Exception)
            {
                throw i_Exception;
            }

            i_Atributes.RemoveRange(0, k_NumOfExpectedAttributes);
        }

        internal override List<string> GetAttributeValuesAsStringList()
        {
            string retValue = string.Format(@"{0} of type {1}, {2:P2} of capacity", m_CurrentFuel, r_FuelType, CurrentPowerPercentage);
            return new List<string> { retValue };
        }
    }
}
