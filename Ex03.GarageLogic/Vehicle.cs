using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string r_LicensePlate;
        protected string m_Model;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        protected Vehicle(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure) 
        {
            r_LicensePlate = i_LicensePlate;
            m_Wheels = new List<Wheel>(i_WheelNum);
            for (int i = 0; i < i_WheelNum; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        protected Vehicle(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure, GasEngine.eGasType i_GasType, float i_TankCapacity)
            : this(i_LicensePlate, i_WheelNum, i_MaxAirPressure)
        {
            m_Engine = new GasEngine(i_GasType, i_TankCapacity);
        }

        protected Vehicle(string i_LicensePlate, int i_WheelNum, float i_MaxAirPressure, float i_BatteryCapacityHours)
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

        public override string ToString()
        {
            return m_Wheels[0].ToString() + m_Engine.ToString() +
                string.Format("license plate: {0},\nmodel: {1},\n", r_LicensePlate, m_Model);
        }



    }
}
