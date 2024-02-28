using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.FuelEngine;


namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure = 0;
        private readonly float r_MaxAirPressure;
        public const int numOfExpectedAttributesWheels = 2;

        public string Manufacturer
        {
            get{ return (string)m_Manufacturer.Clone(); }
            
            set{ m_Manufacturer = value; }
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

        internal void FillAirToMax()
        {
            m_AirPressure = r_MaxAirPressure;
        }

        internal virtual List<string> GetAttributesList(string i_WheelName)
        {
            string attributeManufacturer = string.Format(@"{0}: Manufacturer", i_WheelName);
            string attributeAirpressure = string.Format(@"{0}: Air pressure to fill (max: {1})", i_WheelName, r_MaxAirPressure);

            return new List<string> { attributeManufacturer, attributeAirpressure };
        }

        internal virtual void EnterAtributes(List<string> i_Atributes, bool i_DeleteFromListAfterUse)
        {
            float amountToFill;

            try
            {
                Manufacturer = i_Atributes[0];
                if (!float.TryParse(i_Atributes[1], out amountToFill))
                {
                    throw new FormatException("Wheels-Amount of air to fill: Wrong format! expected Air Pressure to fill to be entered as a float!");
                }
                FillAir(amountToFill);
            }
            catch (Exception i_Exception)
            {
                throw i_Exception;
            }

            if (i_DeleteFromListAfterUse)
            {
                i_Atributes.RemoveRange(0, numOfExpectedAttributesWheels);
            }
        }

        internal virtual  List<string> GetAttributeValuesAsStringList()
        {
            return new List<string> { m_Manufacturer, m_AirPressure.ToString() };
        }
    }
}
