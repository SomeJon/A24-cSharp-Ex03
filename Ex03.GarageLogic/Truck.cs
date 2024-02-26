using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        internal const byte k_TruckWheelNum = 12;
        internal const float k_TruckMaxAirPressure = 28;
        internal const float k_TruckTankCapacityLiters = 110f;
        internal const GasEngine.eGasType k_TruckGasType = GasEngine.eGasType.Soler;
        private bool m_HazardousMaterialsl;
        private float m_CargoVolume;

        internal Truck(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType, float i_TankCapacityLiters)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_GasType, i_TankCapacityLiters) { }

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "does truck carries hazardous material? (yes/no)",
                "truck's cargo's volume" };
        }
    }
}
