using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_TruckWheelNum = 12;
        private const float k_TruckMaxAirPressure = 28;
        private bool m_HazardousMaterial;
        private float m_CargoVolume;

        internal Truck(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine) 
        {
            for (int i = 0; i < k_TruckWheelNum; i++)
            {
                m_Wheels.Add(new Wheel(k_TruckMaxAirPressure));
            }
        }

        public override List<string> GetAttributesList()
        {
            List<string> attributeBase = base.GetAttributesList();
            List<string> attributeNeeded = new List<string> { "Hazardous Material(no/yes)", "Cargo Volume" };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        public override void EnterAtributes(List<string> i_Atributes)
        {
            const int numOfExpectedAttributes = 2;

            try
            {
                base.EnterAtributes(i_Atributes);
                m_HazardousMaterial = turnStringbool(i_Atributes[0]);
                if (!bool.TryParse(i_Atributes[0], out m_HazardousMaterial))
                
                if (!float.TryParse(i_Atributes[1], out m_CargoVolume))
                {
                    throw new FormatException("Truck-Cargo Volume: Wrong format! Expected a float");
                }
            }
            catch (Exception i_Exception)
            {
                throw i_Exception;
            }

            i_Atributes.RemoveRange(0, numOfExpectedAttributes);
        }

        public override List<string> GetAttributeValuesAsStringList()
        {
            List<string> attributeBase = base.GetAttributeValuesAsStringList();
            List<string> attributeNeeded = new List<string> { m_HazardousMaterial.ToString(), m_CargoVolume.ToString() };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        private bool turnStringbool(string i_WantedBool)
        {
            bool retBool;

            if (String.Equals(i_WantedBool, "yes", StringComparison.OrdinalIgnoreCase))
            {
                retBool = true;
            }
            else if (String.Equals(i_WantedBool, "no", StringComparison.OrdinalIgnoreCase))
            {
                retBool = false;
            }
            else
            {
                throw new FormatException("Truck-Hazardous Material: Wrong format! Expected no/yes!");
            }

            return retBool;
        }
    }
}
