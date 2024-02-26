using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehicleFactory
    {
        internal enum eVehicleOptions
        {
            NonElectricCar = 1,
            ElectricCar,
            NonElectricMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        internal Vehicle CreateVehicle(eVehicleOptions i_VehicleChoice, string i_LicensePlate)
        {
            Vehicle vehicle = null;

            switch(i_VehicleChoice)
            {
                case eVehicleOptions.NonElectricCar:
                    vehicle =  new Car(i_LicensePlate, Car.k_CarWheelNum, Car.k_CarMaxAirPressure,
                        Car.k_NonElectricCarGasType, Car.k_NonElectricCarTankCapacityLiters);
                    break;
                case eVehicleOptions.ElectricCar:
                    vehicle = new Car(i_LicensePlate, Car.k_CarWheelNum, Car.k_CarMaxAirPressure, Car.k_ElectricCarBatteryCapacityHours);
                    break;
                case eVehicleOptions.NonElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, Motorcycle.k_MotorcycleWheelNum, Motorcycle.k_MotorcycleMaxAirPressure,
                        Motorcycle.k_NonElectricMotorcycleGasType, Motorcycle.k_NonElectricMotorcycleTankCapacityLiters);
                    break;
                case eVehicleOptions.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, Motorcycle.k_MotorcycleWheelNum, Motorcycle.k_MotorcycleMaxAirPressure,
                        Motorcycle.k_ElectricMotorcycleBatteryCapacityHours);
                    break;
                case eVehicleOptions.Truck:
                    vehicle = new Truck(i_LicensePlate, Truck.k_TruckWheelNum, Truck.k_TruckMaxAirPressure,
                        Truck.k_TruckGasType, Truck.k_TruckTankCapacityLiters);
                    break;
            }

            return vehicle;
        }
    }
}
