using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GasEngine : Engine
    {
        internal enum eGasType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private readonly float r_TankCapacityLiters;
        private readonly eGasType r_GasType;

        public GasEngine(eGasType i_GasTyp, float i_TankCapacityLiters)
        {
            r_GasType = i_GasTyp;
            r_TankCapacityLiters = i_TankCapacityLiters;
        }

        private void FillGasTank(float i_LitersToAdd, eGasType i_GasType)
        {
            if (i_GasType != r_GasType)
            {
                //exception
            }
            else if (m_CurrentPowerPercentage + i_LitersToAdd > r_TankCapacityLiters)
            {
                //exception
            }
            else
            {
                m_CurrentPowerPercentage += i_LitersToAdd;
            }
        }

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "vehicle's fuel level in liters" };
        }
    }
}
