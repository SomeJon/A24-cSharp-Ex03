using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal enum eColor
        {
            Blue = 1,
            White,
            Red,
            Yellow
        }

        private const int k_MinDoors = 2;
        private const int k_MaxDoors= 5;
        private const int k_CarWheelNum = 5;
        private const float k_WheelMaxAirPressure = 30; 
        private eColor m_Color;
        private int m_NumOfDoors;

        internal Car(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine) 
        {
            for(int i = 0; i < k_CarWheelNum; i++)
            {
                m_Wheels.Add(new Wheel(k_WheelMaxAirPressure));
            }
        }


        public override List<string> GetAttributeNameList()
        {
            List<string> attributeBase = base.GetAttributeNameList();
            List<string> attributeNeeded = new List<string> { "Car Color", "Number of Doors" };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        public override void EnterAtributes(List<string> i_Atributes)
        {
            const int k_NumOfExpectedAttributes = 2;
            int inputedValue;

            try
            {
                base.EnterAtributes(i_Atributes);
                m_Color = turnStringToEColor(i_Atributes[0]);
                if(!int.TryParse(i_Atributes[1], out inputedValue))
                {
                    throw new FormatException("Car-Doors: Wrong format! Expected an int");
                }
                FrequantActions.EnterintValueInRange(ref m_NumOfDoors, inputedValue, "Number of doors", k_MaxDoors, k_MinDoors);
                
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
            List<string> attributeNeeded = new List<string> { m_Color.ToString(), m_NumOfDoors.ToString() };

            attributeBase.AddRange(attributeNeeded);
            return attributeBase;
        }

        private eColor turnStringToEColor(string i_Color) 
        {
            eColor retColor;

            if (String.Equals(i_Color, eColor.Blue.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                retColor = eColor.Blue;
            }
            else if (String.Equals(i_Color, eColor.White.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                retColor = eColor.White;
            }
            else if (String.Equals(i_Color, eColor.Red.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                retColor = eColor.Red;
            }
            else if (String.Equals(i_Color, eColor.Yellow.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                retColor = eColor.Yellow;
            }
            else
            {
                StringBuilder availableColors = new StringBuilder();
                string exceptionMsg;

                foreach(string colorName in Enum.GetNames(typeof(eColor)))
                {
                    availableColors.AppendLine(colorName);
                }

                exceptionMsg = string.Format(
@"Car-Color: Wrong format! Expected a defined color! 
Defined Colors:
{0}", availableColors);
                throw new FormatException(exceptionMsg);
            }

            return retColor;
        }
    }
}
