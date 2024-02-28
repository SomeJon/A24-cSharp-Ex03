using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_LicensePlate;
        protected string m_Model;
        protected List<Wheel> m_Wheels = new List<Wheel>();
        protected Engine m_Engine;
        private static bool s_LoadAllWheelsAtOnce = true;

        public static bool LoadAllWheelsAtOnce
        {
            get { return s_LoadAllWheelsAtOnce; }
        }

        public static void SwitchLoadAllWheelsAtOnce()
        {
            s_LoadAllWheelsAtOnce = !s_LoadAllWheelsAtOnce;
        }

        internal Vehicle(string i_LicensePlate, Engine i_VehicleEngine)
        {
            r_LicensePlate  = i_LicensePlate;
            m_Engine        = i_VehicleEngine;
        }

        internal string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        public override bool Equals(object i_Compare)
        {
            bool isEqual = false;
            Vehicle asVehicle = i_Compare as Vehicle;
            string asString = i_Compare as string;

            if (asVehicle == null)
            {
                isEqual = r_LicensePlate == asVehicle.r_LicensePlate;
            }
            else if (asString != null)
            {
                isEqual = r_LicensePlate == asString;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return r_LicensePlate.GetHashCode();
        }

        public static bool operator ==(Vehicle i_Card, object i_Compare)
        {
            return Equals(i_Card, i_Compare);
        }

        public static bool operator !=(Vehicle i_Card, object i_Compare)
        {
            return !(i_Card == i_Compare);
        }

        public static bool operator ==(Vehicle i_Card, string i_Compare)
        {
            return i_Card.r_LicensePlate == i_Compare;
        }

        public static bool operator !=(Vehicle i_Card, string i_Compare)
        {
            return !(i_Card == i_Compare);
        }

        public virtual List<string> GetAttributesList()
        {
            List<string> attributeNeeded = new List<string> { "Model Name" };
            attributeNeeded.AddRange(m_Engine.GetAttributesList());
            if (LoadAllWheelsAtOnce)
            {
                attributeNeeded.AddRange(m_Wheels[0].GetAttributesList("All Wheels"));
            }
            else
            {
                int count = 1;
                foreach (Wheel wheel in m_Wheels)
                {
                    List<string> attributeWheel = wheel.GetAttributesList(string.Format(@"Wheel {0}", count));
                    attributeNeeded.AddRange(attributeWheel);
                    count++;
                }
            }

            return attributeNeeded;
        }

        public virtual void EnterAtributes(List<string> i_Atributes)
        {
            const int numOfExpectedAttributes = 1;
            const bool v_DeleteWheelAttribue = true;

            try
            {
                m_Model = i_Atributes[0];
                i_Atributes.RemoveRange(0, numOfExpectedAttributes);
                m_Engine.EnterAtributes(i_Atributes);
                if (LoadAllWheelsAtOnce)
                {
                    foreach (Wheel wheel in m_Wheels)
                    {
                        wheel.EnterAtributes(i_Atributes, !v_DeleteWheelAttribue);
                    }
                    i_Atributes.RemoveRange(0, Wheel.numOfExpectedAttributesWheels);
                }
                else
                {
                    foreach (Wheel wheel in m_Wheels)
                    {
                        wheel.EnterAtributes(i_Atributes, v_DeleteWheelAttribue);
                    }
                }
            }
            catch(Exception i_Exception) 
            {
                throw i_Exception;
            }
        }

        public virtual List<string> GetAttributeValuesAsStringList()
        {
            List<string> retList = new List<string> { m_Model };
            retList.AddRange(m_Engine.GetAttributeValuesAsStringList());

            return retList;
        }
    }
}
