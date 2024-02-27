using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        internal enum eFuelType
        {
            Octan95,
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

        internal void FillFuelTank(float i_AmountOfFuel)
        {
            try
            {
                CurrentFuel += i_AmountOfFuel;
            }
            catch (ValueOutOfRangeException io_FailedFillingFuel)
            {
                throw io_FailedFillingFuel;
            }
        }

        //public override string ToString()
        //{
        //}
    }
}
