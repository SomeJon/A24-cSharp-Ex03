using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class GarageInterface
    {
        internal enum eMenueOptions
        {
            Exit,
            EnterNewCar,
            ShowLicensePlates,
            ChangeCarState,
            InflateCarWheels,
            FuelUpVehicle,
            ChargeUpVehicle,
            FullShowCar
        }

        private GarageData m_Garage;
        internal const int k_NumOfFirstMenuOption = 0;
        internal const int k_NumOfLastMenuOption = 7;

        private void FullVehicleShow()
        {
            string licensePlate = UI.GetLicensePlate();

            //if(!m_Garage.ShowVehicleFullDetails(licensePlate))
            //{
            //    Console.WriteLine(UI.Messages.k_VehicleNotInGarage);
            //}
        }

        internal void MenuRun(out bool o_StillRunning)
        {
            eMenueOptions userChoice;
            
            o_StillRunning = true;
            UI.Menu(out userChoice);

            switch (userChoice) 
            {
                case eMenueOptions.EnterNewCar:
                    EnterNewVehicle();
                    break;
                default:
                    o_StillRunning = false;
                    break;

            }
        }

        internal void EnterNewVehicle()
        {
            string recivedLicense = UI.GetLicensePlate();
            List<string> recivedAttributes;
            GarageVehicleCard newCard;

            if (m_Garage.isVehicleInGarage(recivedLicense))
            {
                UI.CarInGarageMessage();
            }
            else
            {
                newCard = new GarageVehicleCard();
                recivedAttributes = UI.GetAttributes(newCard.GetAttributesList(), "Card entry");
                newCard.EnterAtributes(recivedAttributes);
            }
        }
    }
}
