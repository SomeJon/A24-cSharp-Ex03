using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicleCard
    {
        public enum eVehicleStatus
        {
            Repair,
            Repaired,
            Paid
        }

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.Repair;
        private Vehicle m_CardVehicle;

        public Vehicle CardVehicle
        {
            get { return m_CardVehicle; }
            set { m_CardVehicle = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public List<string> GetAttributesList()
        {
            return new List<string> { "Owner's name", "Owner's phone number"};
        }

        public void EnterAtributes(List<string> i_Atributes)
        {
            m_OwnerName = i_Atributes[0];
            m_OwnerPhoneNumber = i_Atributes[1];
        }
    }
}
