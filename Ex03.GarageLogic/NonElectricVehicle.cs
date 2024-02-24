using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct NonElectricVehicle
    {
        public enum eFuelKind
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private readonly eFuelKind r_FuelKind;
        private readonly float r_MaxFuelCapacityLiters;
        private float m_FuelLevelLiters;
        public NonElectricVehicle(eFuelKind i_FuelKind, float i_MaxFuelCapacityLiters) 
        {
            r_FuelKind = i_FuelKind;
            r_MaxFuelCapacityLiters = i_MaxFuelCapacityLiters;
            m_FuelLevelLiters = 0;
        }

        public float FuelLevelLiters 
        {
            set {  m_FuelLevelLiters = value;}
            get { return m_FuelLevelLiters;}
        }
        private void FuelUp(float i_LitersToAdd, eFuelKind i_FuelKind)
        {
            if(i_FuelKind != r_FuelKind)
            {
                //exception
            }
            else if(m_FuelLevelLiters + i_LitersToAdd > r_MaxFuelCapacityLiters)
            {
                //exception
            }
            else
            {
                m_FuelLevelLiters += i_LitersToAdd;
            }
        }
    }
}
