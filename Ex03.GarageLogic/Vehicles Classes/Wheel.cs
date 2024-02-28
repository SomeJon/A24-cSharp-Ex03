using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure = 0;
        private readonly float r_MaxAirPressure;

        public string Manufacturer
        {
            get{ return (string)m_Manufacturer.Clone(); }
            
            set
            {
                try
                {
                    m_Manufacturer = value;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            private set 
            {
                try
                {
                    FrequantActions.EnterFloatValueInRange(ref m_AirPressure, value, "Air Pressure", r_MaxAirPressure);
                }
                catch(ValueOutOfRangeException io_MaxAirPressurePassed)
                {
                    throw io_MaxAirPressurePassed;
                }
            }
        }

        public float MaxAirPressure{ get { return r_MaxAirPressure; }}

        internal Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }  

        internal void FillAir(float i_AmountOfAirToFill)
        {
            try
            {
                AirPressure += i_AmountOfAirToFill;
            }
            catch(ValueOutOfRangeException io_FailedAddingAirPressure)
            {
                throw io_FailedAddingAirPressure;
            }
        }

        //internal List<string> GetAttributesList()
        //{
            //todo
        //}

        //public override string ToString()
        //{
            //todo
        //}
    }
}
