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

        internal const int k_CarWheelNum = 5;
        internal const float k_CarMaxAirPressure = 30;
        internal const float k_NonElectricCarTankCapacityLiters = 58;
        internal const GasEngine.eGasType k_NonElectricCarGasType = GasEngine.eGasType.Octan95;
        internal const float k_ElectricCarBatteryCapacityHours = 4.8f;
        private eColor m_Color;
        private int m_NumOfDoors;

        internal Car(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType, float i_TankCapacityLiters)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_GasType, i_TankCapacityLiters) { }

        internal Car(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure, float i_BatteryCapacityHours)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_BatteryCapacityHours) { }

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "a number for car's color. options are:\n1- blue\n2- white\n3- red\n4-yellow",
                "car's number of doors" };
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("color: {0},\nnumber of doors: {1}\n", m_Color, m_NumOfDoors);
        }


    }
}
