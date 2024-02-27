using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicleCard
    {
        private enum eVehicleStatus
        {
            Repair,
            Repaired,
            Paid
        }

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus = eVehicleStatus.Repair;
        private Vehicle m_Vehicle;

        internal List<string> GetAttributesList()
        {
            return new List<string> { "owner's name", "owner's phone number" };
        }

        public override bool Equals(object i_LicensePlate)
        {
            bool eqauls = false;
            string toCompareTo = i_LicensePlate as string;
            if (toCompareTo != null)
            {
                eqauls = this.GetHashCode() == i_LicensePlate.GetHashCode();
            }

            return eqauls;
        }

        public override int GetHashCode()
        {
            return m_Vehicle.LicensePlate.GetHashCode();
        }

        public static bool operator ==(GarageVehicleCard i_Vehicle1, GarageVehicleCard i_Vehicle2)
        {
            return i_Vehicle1.GetHashCode() == i_Vehicle2.GetHashCode();
        }

        public static bool operator !=(GarageVehicleCard i_Vehicle1, GarageVehicleCard i_Vehicle2)
        {
            return i_Vehicle1.GetHashCode() != i_Vehicle2.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("the vehicle is a: {0},\nowner's name: {1},\nvehicle's status: {2}\n",
                m_Vehicle.GetType().Name , m_OwnerName, m_VehicleStatus) + m_Vehicle.ToString();
        }
    }
}
