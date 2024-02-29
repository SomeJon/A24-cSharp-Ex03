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
        private readonly string r_LicensePlate;
        private string m_Model;
        protected List<Wheel> m_Wheels = new List<Wheel>();
        private Engine m_Engine;
        private static bool s_LoadAllWheelsAtOnce = true;

        public Engine Engine 
        { 
            get { return m_Engine; } 
        }
        public static bool LoadAllWheelsAtOnce
        {
            get { return s_LoadAllWheelsAtOnce; }
        }

        public string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        internal Vehicle(string i_LicensePlate, Engine i_VehicleEngine)
        {
            r_LicensePlate  = i_LicensePlate;
            m_Engine        = i_VehicleEngine;
        }

        public bool IsElectric()
        {
            return m_Engine is ElectricEngine;
        }

        internal void FillWheelsToMax()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.FillAirToMax();
            }
        }

        public static void SwitchLoadAllWheelsAtOnce()
        {
            s_LoadAllWheelsAtOnce = !s_LoadAllWheelsAtOnce;
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

        /// <summary>
        /// We are going for a load and save system in each class of vehicle, where the UI can ask for the needed
        /// paramters name and ask for them in order, and then ask to load them. the UI can also recive the paramters
        /// values and print them as it show fit, rather then reciving a premade list and then being stuck with how
        /// the string is built. also, if so desired by future UI, it allows saving into files and reading from files
        /// without a change to the dll.
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetAttributeNameList()
        {
            List<string> attributeNeeded = new List<string> { "Model Name" };
            attributeNeeded.AddRange(m_Engine.GetAttributeNameList());
            if (LoadAllWheelsAtOnce)
            {
                attributeNeeded.AddRange(m_Wheels[0].GetAttributeNameList("All Wheels"));
            }
            else
            {
                int count = 1;
                foreach (Wheel wheel in m_Wheels)
                {
                    List<string> attributeWheel = wheel.GetAttributeNameList(string.Format(@"Wheel {0}", count));
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
                    i_Atributes.RemoveRange(0, Wheel.k_NumOfExpectedAttributesWheels);
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
            foreach (Wheel wheel in m_Wheels)
            {
                retList.AddRange(wheel.GetAttributeValuesAsStringList());
            }

            return retList;
        }
    }
}
