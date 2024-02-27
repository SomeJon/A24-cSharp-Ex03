using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal enum eColor
        {
            Blue = 1,
            White,
            Red,
            Yellow
        }

        internal const int k_CarWheelNum = 5; //
        internal const float k_WheelMaxAirPressure = 30; //
        internal const float k_NonElectricCarTankCapacityLiters = 58; //
        internal const GasEngine.eGasType k_NonElectricCarGasType = GasEngine.eGasType.Octan95; //
        internal const float k_ElectricCarBatteryCapacityHours = 4.8f; //
        private eColor m_Color;
        private int m_NumOfDoors;

        internal Car(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine) { }


        internal override List<string> GetAttributesList()
        {
        }

        public override string ToString()
        {
        }


    }
}
