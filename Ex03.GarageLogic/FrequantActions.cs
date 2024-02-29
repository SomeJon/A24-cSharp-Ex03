using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Ex03.GarageLogic
{
    public class FrequantActions
    {
        public static void EnterFloatValueInRange(out float o_Value, float i_Value, string i_ValueName, float i_MaxValue, float i_MinValue = 0)
        {
            if (i_Value <= i_MaxValue && i_Value >= i_MinValue)
            {
                o_Value = i_Value;
            }
            else
            {
                string errorMessage =
                    string.Format("Out of possible capacity for {0}! Capacity of {0} is: {1} - {2}", i_ValueName, i_MinValue, i_MaxValue);
                throw new ValueOutOfRangeException(errorMessage, i_MaxValue, i_MinValue);
            }
        }

        public static void EnterintValueInRange(out int o_Value, int i_Value, string i_ValueName, int i_MaxValue, int i_MinValue = 0)
        {
            if (i_Value <= i_MaxValue && i_Value >= i_MinValue)
            {
                o_Value = i_Value;
            }
            else
            {
                string errorMessage =
                    string.Format("Out of possible capacity for {0}! Capacity of {0} is: {1} - {2}", i_ValueName, i_MinValue, i_MaxValue);
                throw new ValueOutOfRangeException(errorMessage, i_MaxValue, i_MinValue);
            }
        }
    }
}
