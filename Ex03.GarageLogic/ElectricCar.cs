using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float k_ElectricCarMaxBatteryCapacity = 4.8f;
        ElectricVehicle m_ElectricVehicle = new ElectricVehicle(k_ElectricCarMaxBatteryCapacity);

        public ElectricCar(string i_LicensePlate) : base(i_LicensePlate) { }
    }
}
