using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
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

        //internal virtual List<string> GetAttributesList()
        //{

        //}

        //public override string ToString()
        //{
            
       // }
    }
}
