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
            List<string> attributeNeeded = new List<string> { "Hazardous Material(0 for no, 1 for yes)", "Cargo Volume" };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        public override void EnterAtributes(List<string> i_Atributes)
        {
            const int numOfExpectedAttributes = 2;

            try
            {
                base.EnterAtributes(i_Atributes);
                if (!bool.TryParse(i_Atributes[0], out m_HazardousMaterial))
                {
                    throw new FormatException("Wrong format! Expected a defined 0 or 1!");

                }
                if (!float.TryParse(i_Atributes[1], out m_CargoVolume))
                {
                    throw new FormatException("Wrong format! Expected a float");
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


            foreach (Wheel wheel in m_Wheels)
            {
                attributeBase.AddRange(wheel.GetAttributeValuesAsStringList());
            }


            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }
    }
}
