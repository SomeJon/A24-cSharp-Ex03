using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentPowerPercentage = 0; //Representing Percentage by value of 0-1

        public float CurrentPowerPercentage
        {
            get { return m_CurrentPowerPercentage; }
            protected set { m_CurrentPowerPercentage = value; }
        }


        internal abstract List<string> GetAttributesList();

        internal abstract void EnterAtributes(List<string> i_Atributes);

        public abstract List<string> GetAttributeValuesAsStringList();

    }
}
