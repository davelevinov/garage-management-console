using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsOfElectricMotorcycle : DetailsOfMotorcycle
    {
        private const float k_MaxChargeTime = 1.8f;
        private const Vehicle.eVehicleType k_VehicleType = Vehicle.eVehicleType.ElectricMotorcycle;

        public DetailsOfElectricMotorcycle(
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
                  new ElectricBattery(k_MaxChargeTime, k_MaxChargeTime), 
                  i_ManufacturerName,
                  k_VehicleType, 
                  i_LicenseType, 
                  i_EngineVolume)
        {
        }

        public float MaxChargeTime
        {
            get
            {
                return k_MaxChargeTime;
            }
        }
    }
}
