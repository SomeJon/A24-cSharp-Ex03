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

        internal override List<string> GetAttributesList()
        {
            return new List<string> { "vehicle's fuel level in liters" };
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("fuel type is:: {0}\n", r_GasType);
        }
    }
}
