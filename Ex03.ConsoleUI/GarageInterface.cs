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

            if(!m_Garage.ShowVehicleFullDetails(licensePlate))
            {
                Console.WriteLine(UI.Messages.k_VehicleNotInGarage);
            }
        }

        internal eMenueOptions MenuRun(eMenueOptions i_MenuOption)
        {
            switch (i_MenuOption) 
            {
                case eMenueOptions.FullShowCar:
                    FullVehicleShow();
                    break;

            }
        }
    }
}
