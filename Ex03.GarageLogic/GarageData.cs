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
        private  List<GarageVehicleCard> m_ListOfVehicles = new List<GarageVehicleCard>();

        public List<GarageVehicleCard> ListOfVehicles
        {
            get { return m_ListOfVehicles; }
        }

        public void AddCardToList(GarageVehicleCard i_CardToAdd)
        {
            m_ListOfVehicles.Add(i_CardToAdd);
        }
        
        public GarageVehicleCard FindVehicle(string i_LicensePlate)
        {
            return m_ListOfVehicles.Find(card => (card.CardVehicle == i_LicensePlate)); ;
        }

        public List<string> FindAllMatchLicences(GarageVehicleCard.eVehicleStatus i_WantedStatus)
        {
            List<GarageVehicleCard> Matches = m_ListOfVehicles.FindAll(card => (card.VehicleStatus == i_WantedStatus));
            return GetLicences(Matches);
        }

        public static List<string> GetLicences(List<GarageVehicleCard> i_WantedList)
        {
            List<string> licences = new List<string>();

            foreach (GarageVehicleCard Card in i_WantedList)
            {
                licences.Add(Card.CardVehicle.LicensePlate);
            }

            return licences;
        }

        public bool isVehicleInGarage(string i_LicensePlate)
        {
            bool carIsInGarage = false;

            GarageVehicleCard VehicleCard = FindVehicle(i_LicensePlate);
            if (VehicleCard != null) 
            {
                carIsInGarage = true;
                VehicleCard.VehicleStatus = GarageVehicleCard.eVehicleStatus.Repair;
            }

            return carIsInGarage;
        }
    }
}
