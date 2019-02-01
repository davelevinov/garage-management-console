using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsOfFuelTruck : DetailsOfTruck
    {
        private const float k_FuelTankCapacity = 115f;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Octan96;
        private const Vehicle.eVehicleType k_VehicleType = Vehicle.eVehicleType.Truck;

        public DetailsOfFuelTruck(
            string i_OwnerName, 
            string i_OwnerPhone, 
            string i_Model, 
            string i_PlateNumber,
            string i_ManufacturerName,
            float i_MaxLoad, 
            bool i_IsCarryingHazardousMaterials)
            : base(
                  i_OwnerName,
                  i_OwnerPhone,
                  i_Model,
                  i_PlateNumber, 
                  new FuelTank(k_FuelTankCapacity, k_FuelTankCapacity, k_FuelType),
                  i_ManufacturerName, 
                  k_VehicleType, 
                  i_MaxLoad, 
                  i_IsCarryingHazardousMaterials)
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
