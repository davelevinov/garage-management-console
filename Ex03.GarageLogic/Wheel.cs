using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected readonly float r_MaxPressure;
        protected string m_ManufacturerName;
        protected float m_CurrentPressure;

        public Wheel(string i_ManufacturerName, float i_MaxPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            r_MaxPressure = i_MaxPressure;

            // default pressure is max
            m_CurrentPressure = i_MaxPressure;
        }

        internal void inflateWheel(float i_addAir)
        {
            float newPressure = m_CurrentPressure + i_addAir;
            if (i_addAir <= 0 || newPressure > r_MaxPressure)
            {
                throw new ValueOutOfRangeException(r_MaxPressure, 0);
            }

            m_CurrentPressure = newPressure;
        }

        internal void inflateWheelToMax()
        {
            m_CurrentPressure = r_MaxPressure;
        }

        public override string ToString()
        {
            string detailsOfWheel = string.Format(
                                                   "Manufacturer Name: {1}{0}Current Pressure: {2}{0}Max Pressure: {3}{0}",
                                                   Environment.NewLine,
                                                   m_ManufacturerName,
                                                   m_CurrentPressure,
                                                   r_MaxPressure);
            return detailsOfWheel;
        }

        public float currentPressure
        {
            get
            {
                return m_CurrentPressure;
            }

            set
            {
                m_CurrentPressure = value;
            }
        }

        public float maxPressure
        {
            get
            {
                return r_MaxPressure;
            }
        }

        public string manufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }
    }
}
