using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        protected float m_CurrentPowerPercentage;

        internal virtual List<string> GetAttributesList()
        {
            return new List<string> { "current power percentage in tank/battery" };
        }

    }
}
