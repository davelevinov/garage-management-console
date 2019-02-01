using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsOfElectricCar : DetailsOfCar
    {
        private const float k_MaxChargeTime = 3.2f;
        private const Vehicle.eVehicleType k_VehicleType = Vehicle.eVehicleType.ElectricCar;

        public DetailsOfElectricCar(
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
                  new ElectricBattery(k_MaxChargeTime, k_MaxChargeTime), 
                  i_ManufacturerName,
                  k_VehicleType, 
                  i_CarColor,
                  i_NumberOFDoors)
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
