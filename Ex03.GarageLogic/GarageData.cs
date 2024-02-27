using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageData
    {
        private const int k_VehicleNotInGarage = -1; 
        private  List<GarageVehicleCard> m_ListOfVehicles;

        private int FindVehicle(string i_LicensePlate)
        {
            GarageVehicleCard toLookFor = new GarageVehicleCard(new Vehicle(i_LicensePlate));
            return m_ListOfVehicles.IndexOf(toLookFor);
        }

        public bool ShowVehicleFullDetails(string i_LicensePlate)
        {
            bool isShowSuccessful = false;
            int index = FindVehicle(i_LicensePlate);

            if (index != k_VehicleNotInGarage)
            {
                m_ListOfVehicles[index].ToString();
                isShowSuccessful = true;
            }

            return isShowSuccessful;
        }
    }
}
