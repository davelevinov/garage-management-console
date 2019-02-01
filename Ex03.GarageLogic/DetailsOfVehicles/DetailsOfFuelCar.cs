using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsOfFuelCar : DetailsOfCar
    {
        private const float k_FuelTankCapacity = 45f;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Octan98;
        private const Vehicle.eVehicleType k_VehicleType = Vehicle.eVehicleType.FuelCar;

        public DetailsOfFuelCar(
            string i_OwnerName, 
            string i_OwnerPhone, 
            string i_Model, 
            string i_PlateNumber,
            string i_ManufacturerName, 
            Car.eCarColor i_CarColor, 
            Car.eNumberOfDoors i_NumberOFDoors) 
            : base(
                  i_OwnerName, 
                  i_OwnerPhone, 
                  i_Model,
                  i_PlateNumber, 
                  new FuelTank(k_FuelTankCapacity, k_FuelTankCapacity, k_FuelType), 
                  i_ManufacturerName,
                  k_VehicleType, 
                  i_CarColor, 
                  i_NumberOFDoors)
        {
        }

        public float FuelTankCapacity
        {
            get
            {
                return k_FuelTankCapacity;
            }
        }

        public FuelTank.eFuelType FuelType
        {
            get
            {
                return k_FuelType;
            }
        }
    }
}
