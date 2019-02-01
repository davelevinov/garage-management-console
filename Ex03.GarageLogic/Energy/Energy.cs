using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_MaxEnergy;
        private float m_RemainingEnergy;

        public Energy(float i_MaxEnergy, float i_RemainingEnergy)
        {
            m_MaxEnergy = i_MaxEnergy;
            m_RemainingEnergy = i_RemainingEnergy;
        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

        public float RemainingEnergyPercent
        {
            get
            {
                return m_MaxEnergy / m_RemainingEnergy * 100;
            }
        }

        protected void FillEnergy(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd <= 0 || m_RemainingEnergy + i_EnergyToAdd > m_MaxEnergy)
            {
                throw new ValueOutOfRangeException(m_MaxEnergy - m_RemainingEnergy, 0);
            }
            else if(m_MaxEnergy == m_RemainingEnergy)
            {
                throw new ArgumentOutOfRangeException("Can't fill tank, tank is full");
            }

            m_RemainingEnergy += i_EnergyToAdd;
        }

        public override string ToString()
        {
            string energyData = string.Format(
                                               "Max Energy: {1}{0}" + "Remaining Energy Percent : {2}%{0}",
                                               Environment.NewLine,
                                               m_MaxEnergy,
                                               RemainingEnergyPercent);
            return energyData;
        }
    }
}
