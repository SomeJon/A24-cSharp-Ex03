using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

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

        internal const int k_MotorcycleWheelNum = 2;
        internal const int k_MotorcycleMaxAirPressure = 29; //
        internal const float k_NonElectricMotorcycleTankCapacityLiters = 5.8f; //
        internal const GasEngine.eGasType k_NonElectricMotorcycleGasType = GasEngine.eGasType.Octan98; //
        internal const float k_ElectricMotorcycleBatteryCapacityHours = 2.8f; //
        private eLicenseType r_LicenseType;
        private int m_EngineVolume;

        internal Motorcycle(string i_LicensePlate, Engine i_Engine): base(i_LicensePlate, i_Engine) { }

        
        internal override List<string> GetAttributesList()
        {
            
        }

        public override string ToString()
        {

        }
    }
}
