using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class GasEngine : Engine
    {
        internal enum eGasType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private readonly float r_TankCapacityLiters;
        private readonly eGasType r_GasType;
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

        public GasEngine(eGasType i_GasType, float i_TankCapacityLiters)
        {
            r_GasType = i_GasType;
            r_TankCapacityLiters = i_TankCapacityLiters;
        }

        internal void FillGasTank(float i_AmountOfGas)
        {
            try
            {
                CurrentFuel += i_AmountOfGas;
            }
            catch (ValueOutOfRangeException io_FailedFillingFuel)
            {
                throw io_FailedFillingFuel;
            }
        }

        public override string ToString()
        {
        }
    }
}
