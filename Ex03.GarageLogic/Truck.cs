using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const byte k_TruckWheelNum = 12;
        private const byte k_TruckMaxAirPressure = 28;
        private const byte k_TruckMaxFuelCapacity = 110;
        private bool m_CarriesHazardousMaterialsl;
        private float m_CargoVolume;
        private NonElectricVehicle m_NonElectricVehicle = new NonElectricVehicle(NonElectricVehicle.eFuelKind.Soler, k_TruckMaxFuelCapacity);
        Wheel[] m_Wheels = new Wheel[k_TruckWheelNum];

        public Truck(string i_LicensePlate) : base(i_LicensePlate)
        {
            for (int i = 0; i < k_TruckWheelNum; i++)
            {
                m_Wheels[i] = new Wheel(k_TruckMaxAirPressure);
            }
        }
    }
}
