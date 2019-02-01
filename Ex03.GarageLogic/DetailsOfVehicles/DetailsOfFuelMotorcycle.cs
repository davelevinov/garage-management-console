using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsOfFuelMotorcycle : DetailsOfMotorcycle
    {
        private const float k_FuelTankCapacity = 6f;
        private const FuelTank.eFuelType k_FuelType = FuelTank.eFuelType.Octan96;
        private const Vehicle.eVehicleType k_VehicleType = Vehicle.eVehicleType.FuelMotorcycle;

        public DetailsOfFuelMotorcycle(
            string i_OwnerName, 
            string i_OwnerPhone, 
            string i_Model, 
            string i_PlateNumber,
            string i_ManufacturerName, 
            Motorcycle.eMotorcycleLicenseType i_LicenseType,
            int i_EngineVolume) 
            : base(
                  i_OwnerName, 
                  i_OwnerPhone, 
                  i_Model,
                  i_PlateNumber, 
                  new FuelTank(k_FuelTankCapacity, k_FuelTankCapacity, k_FuelType), 
                  i_ManufacturerName,
                  k_VehicleType, 
                  i_LicenseType, 
                  i_EngineVolume)
        {
        }

        public float FuelTankTankCapacity
        {
            get
            {
                return k_FuelTankCapacity;
            }
        }

        public FuelTank.eFuelType FuelTankType
        {
            get
            {
                return k_FuelType;
            }
        }
    }
}
