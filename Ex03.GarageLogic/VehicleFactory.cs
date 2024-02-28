using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eVehicleOptions
        {
            FuelCar = 1,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck
        }

        public static List<string>  s_VehicleOptions = new List<string> 
            { "Normal Car", "Electric Car", "Normal Motorcycle", "ElectricMotorcycle", "Truck"};

        public static Vehicle CreateVehicle(eVehicleOptions i_VehicleChoice, string i_LicensePlate)
        {
            Vehicle newVehicleBase;

            switch (i_VehicleChoice)
            {
                case eVehicleOptions.FuelCar:
                    newVehicleBase = createFuelCarBase(i_LicensePlate);
                    break;
                case eVehicleOptions.ElectricCar:
                    newVehicleBase = createElectricCarBase(i_LicensePlate);
                    break;
                case eVehicleOptions.FuelMotorcycle:
                    newVehicleBase = createFuelMotorcycleBase(i_LicensePlate);
                    break;
                case eVehicleOptions.ElectricMotorcycle:
                    newVehicleBase = createElectricMotorcycleBase(i_LicensePlate);
                    break;
                case eVehicleOptions.Truck:
                    newVehicleBase = createTruckBase(i_LicensePlate);
                    break;
                default:
                    throw new Exception("No car to create was found");
            }

            return newVehicleBase;
        }

        private static Vehicle createFuelCarBase(string i_LicensePlate)
        {
            const float k_CarFuelTankCapacityLiters = 58;
            const FuelEngine.eFuelType k_FuelCarFuelType = FuelEngine.eFuelType.Octan95;

            Engine carEngine = new FuelEngine(k_FuelCarFuelType, k_CarFuelTankCapacityLiters);
            return new Car(i_LicensePlate, carEngine);
        }

        private static Vehicle createElectricCarBase(string i_LicensePlate)
        {
            const float k_CarElectricBatteryCapacityHours = 4.8f;

            Engine carEngine = new ElectricEngine(k_CarElectricBatteryCapacityHours);
            return new Car(i_LicensePlate, carEngine);
        }

        private static Vehicle createFuelMotorcycleBase(string i_LicensePlate)
        {
            const float k_FuelMotorcycleTankCapacityLiters = 5.8f;
            const FuelEngine.eFuelType k_FuelMotorcycleGasType = FuelEngine.eFuelType.Octan98;

            Engine motorcycleEngine = new FuelEngine(k_FuelMotorcycleGasType, k_FuelMotorcycleTankCapacityLiters);
            return new Motorcycle(i_LicensePlate, motorcycleEngine);
        }

        private static Vehicle createElectricMotorcycleBase(string i_LicensePlate)
        {
            const float k_ElectricMotorcycleBatteryCapacityHours = 2.8f;

            Engine motorcycleEngine = new ElectricEngine(k_ElectricMotorcycleBatteryCapacityHours);
            return new Motorcycle(i_LicensePlate, motorcycleEngine);
        }

        private static Vehicle createTruckBase(string i_LicensePlate)
        {
            const float k_TruckTankCapacityLiters = 110f;
            const FuelEngine.eFuelType k_TruckFuelType = FuelEngine.eFuelType.Soler;

            Engine motorcycleEngine = new FuelEngine(k_TruckFuelType, k_TruckTankCapacityLiters);
            return new Motorcycle(i_LicensePlate, motorcycleEngine);
        }
    }
}
