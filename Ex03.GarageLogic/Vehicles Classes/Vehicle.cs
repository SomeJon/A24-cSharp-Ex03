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
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

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

        //internal virtual List<string> GetAttributesList()
        //{

        //}

        //public override string ToString()
        //{

        // }
    }
}
