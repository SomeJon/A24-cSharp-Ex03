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
        internal const float k_TruckMaxAirPressure = 28; //
        internal const float k_TruckTankCapacityLiters = 110f; //
        internal const GasEngine.eGasType k_TruckGasType = GasEngine.eGasType.Soler; //
        private bool m_HazardousMaterialsl;
        private float m_CargoVolume;

        internal Truck(string i_LicensePlate, Engine i_Engine)
            : base(i_LicensePlate, i_Engine) { }

        internal override List<string> GetAttributesList()
        {
            
        }

        public override string ToString()
        {
            
        }
    }
}
