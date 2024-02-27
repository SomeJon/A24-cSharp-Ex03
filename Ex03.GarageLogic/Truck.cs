using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        internal const int k_TruckWheelNum = 12;
        internal const float k_TruckMaxAirPressure = 28;
        internal const float k_TruckTankCapacityLiters = 110f;
        internal const GasEngine.eGasType k_TruckGasType = GasEngine.eGasType.Soler;
        private bool m_HazardousMaterialsl;
        private float m_CargoVolume;

        internal Truck(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType, float i_TankCapacityLiters)
            : base(i_LicensePlate, i_WheelNum, i_MaxAirPressure, i_GasType, i_TankCapacityLiters) { }

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "does truck carries hazardous material? (yes/no)",
                "truck's cargo's volume" };
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("does truck carry hazarous materials: {0},\ncargo volume: {1}\n",
                (m_HazardousMaterialsl ? "yes" : "no"), m_CargoVolume);
        }
    }
}
