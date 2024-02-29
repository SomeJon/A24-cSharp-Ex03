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
            Repair = 1,
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

        public virtual List<string> GetAttributeNameList()
        {
            return new List<string> { "Owner's name", "Owner's phone number"};
        }

        public virtual void EnterAtributes(List<string> i_Atributes)
        {
            m_OwnerName = i_Atributes[0];
            m_OwnerPhoneNumber = i_Atributes[1];
        }

        public virtual List<string> GetAttributeValuesAsStringList()
        {
            List<string> retList = new List<string> { m_OwnerName, m_OwnerPhoneNumber };

            return retList;
        }
    }
}
