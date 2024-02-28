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
        private  List<GarageVehicleCard> m_ListOfVehicles = null;

        public void AddCardToList(GarageVehicleCard i_CardToAdd)
        {
            m_ListOfVehicles.Add(i_CardToAdd);
        }
        
        private GarageVehicleCard FindVehicle(string i_LicensePlate)
        {
            return m_ListOfVehicles.Find(card => (card.CardVehicle == i_LicensePlate));
        }

        public bool isVehicleInGarage(string i_LicensePlate)
        {
            bool carIsInGarage = false;
            GarageVehicleCard VehicleCard = FindVehicle(i_LicensePlate);

            if (VehicleCard != null)
            {
                carIsInGarage = true;
            }

            return carIsInGarage;
        }
    }
}
