using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class NonElectricCar : Car
    {
        private const float k_NonElectricCarMaxFuelCapacity = 58;
        NonElectricVehicle m_NonElectricVehicle = new NonElectricVehicle(NonElectricVehicle.eFuelKind.Octan95, k_NonElectricCarMaxFuelCapacity);

        public NonElectricCar(string i_LicensePlate) : base(i_LicensePlate) { }
    }
}
