using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eVehicleType
        {
            FuelCar = 1,
            ElectricCar = 2,
            FuelMotorcycle = 3,
            ElectricMotorcycle = 4,
            Truck = 5
        }

        private DetailsOfVehicle m_DetailsOfVehicle;

        public Vehicle(DetailsOfVehicle i_DetailsOfVehicle)
        {
            m_DetailsOfVehicle = i_DetailsOfVehicle;
        }

        public DetailsOfVehicle DetailsOfVehicle
        {
            get
            {
                return m_DetailsOfVehicle;
            }
        }

        public override string ToString()
        {
            return m_DetailsOfVehicle.ToString();
        }
    }
}