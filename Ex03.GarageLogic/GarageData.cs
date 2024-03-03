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

        public void AddCardToList(GarageVehicleCard i_VehicleToAdd)
        {
            m_ListOfVehicles.Add(i_VehicleToAdd);
        }
        
        public GarageVehicleCard FindVehicle(string i_LicensePlate)
        {
            return m_ListOfVehicles.Find(card => (card.CardVehicle == i_LicensePlate)); ;
        }

        public void FillVehicleWheelsToMax(string i_VehicleLicenseToAddAirToWheels)
        {
            GarageVehicleCard foundCard = this.FindVehicle(i_VehicleLicenseToAddAirToWheels);

            if (foundCard != null)
            {
                try
                {
                    foundCard.CardVehicle.FillWheelsToMax();
                }
                catch (Exception i_Exception)
                {
                    throw i_Exception;
                }
            }
            else
            {
                throw new Exception("Card Could not be found!");
            }
        }

        public List<string> FindAllMatchLicences(GarageVehicleCard.eVehicleStatus i_WantedStatus)
        {
            List<GarageVehicleCard> Matches = 
                m_ListOfVehicles.FindAll(card => (card.VehicleStatus == i_WantedStatus));
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

        public bool IsVehicleInGarage(string i_LicensePlate)
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
