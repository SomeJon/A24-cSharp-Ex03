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

        internal const int k_NumOfFirstMenuOption = 0;
        internal const int k_NumOfLastMenuOption = 7;
    }
}
