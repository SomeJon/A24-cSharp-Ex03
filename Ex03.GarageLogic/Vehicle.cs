using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_Model;
        protected readonly string r_LicensePlate;
        protected List<Wheel> m_Wheel;
        protected Engine m_Engine;

        protected Vehicle(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure) 
        {
            r_LicensePlate = i_LicensePlate;
            m_Wheel = new List<Wheel>(i_WheelNum);
            for (int i = 0; i < i_WheelNum; i++)
            {
                m_Wheel.Add(new Wheel(i_MaxAirPressure));
            }
        }

        protected Vehicle(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType, float i_TankCapacity)
            : this(i_LicensePlate, i_WheelNum, i_MaxAirPressure)
        {
            m_Engine = new GasEngine(i_GasType, i_TankCapacity);
        }

        protected Vehicle(string i_LicensePlate, byte i_WheelNum, float i_MaxAirPressure, float i_BatteryCapacityHours)
            : this(i_LicensePlate, i_WheelNum, i_MaxAirPressure)
        {
            m_Engine = new ElectricEngine(i_BatteryCapacityHours);
        }

        internal string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        internal virtual List<string> GetAttributesList()
        {
            return new List<string> { "car's model", "license plate" };
        }

    }
}
