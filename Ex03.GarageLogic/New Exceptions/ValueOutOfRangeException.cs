using System;


namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        { get { return m_MaxValue; } }

        public float MinValue
        { get { return m_MinValue; } }

        public ValueOutOfRangeException(string i_Message, float i_MaxValue, float i_MinValue = 0) : base(i_Message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(string i_Message, float i_MaxValue, float i_MinValue, Exception i_InnerException) : base(i_Message, i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
