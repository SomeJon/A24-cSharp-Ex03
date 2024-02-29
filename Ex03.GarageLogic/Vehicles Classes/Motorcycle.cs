using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseType
        {
            A1,
            A2,
            AB,
            B2
        }

        private const int k_MotorcycleWheelNum = 2;
        private const int k_MotorcycleMaxAirPressure = 29;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        internal Motorcycle(string i_LicensePlate, Engine i_Engine): base(i_LicensePlate, i_Engine) 
        {
            for (int i = 0; i < k_MotorcycleWheelNum; i++)
            {
                m_Wheels.Add(new Wheel(k_MotorcycleMaxAirPressure));
            }
        }


        public override List<string> GetAttributeNameList()
        {
            List<string> attributeBase = base.GetAttributeNameList();
            List<string> attributeNeeded = new List<string> { "License Type", "Engine Volume" };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        public override void EnterAtributes(List<string> i_Atributes)
        {
            const int k_NumOfExpectedAttributes = 2;
            bool isInputOk;

            try
            {
                base.EnterAtributes(i_Atributes);
                isInputOk = eLicenseType.TryParse(i_Atributes[0], out m_LicenseType);
                if (!isInputOk || !Enum.IsDefined(typeof(eLicenseType), m_LicenseType))
                {
                    throw new FormatException("Motorcycle-LicenseType: Wrong format! Expected a defined License Type!");

                }
                if (!int.TryParse(i_Atributes[1], out m_EngineVolume))
                {
                    throw new FormatException("Motorcycle-EngineVolume: Wrong format! Expected an int");
                }
            }
            catch (Exception i_Exception)
            {
                throw i_Exception;
            }

            i_Atributes.RemoveRange(0, k_NumOfExpectedAttributes);
        }

        public override List<string> GetAttributeValuesAsStringList()
        {
            List<string> attributeBase = base.GetAttributeValuesAsStringList();
            List<string> attributeNeeded = new List<string> { m_LicenseType.ToString(), m_EngineVolume.ToString() };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }
    }
}
