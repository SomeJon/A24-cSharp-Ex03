using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseType
        {
            A1,
            A2,
            AB,
            B2
        }

        internal const byte k_MotorcycleWheelNum = 2;
        internal const byte k_MotorcycleMaxAirPressure = 29;
        internal const float k_NonElectricMotorcycleTankCapacityLiters = 5.8f;
        internal const GasEngine.eGasType k_NonElectricMotorcycleGasType = GasEngine.eGasType.Octan98;
        internal const float k_ElectricMotorcycleBatteryCapacityHours = 2.8f;
        private readonly eLicenseType r_LicenseType;
        private int m_EngineVolume;

        internal Motorcycle(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType,
            float i_TankCapacityLiters)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_GasType, i_TankCapacityLiters) { }

    internal Motorcycle(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure, float i_BatteryCapacityHours)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_BatteryCapacityHours) { }
        
        internal override List<string> GetAttributesList()
        {
            return new List<string> { "a number for motorcycle's license. options are:\n1- A1\n2- A2\n3- AB\n4-B2",
                "engine's volume" };
        }
    }
}
