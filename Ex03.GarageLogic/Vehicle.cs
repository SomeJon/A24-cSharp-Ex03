using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        protected string m_Model;
        protected readonly string r_LicensePlate;
        protected float m_energyTank;
        
        public Vehicle(string i_LicensePlate)
        {
            r_LicensePlate = i_LicensePlate;
        }

    }
}
