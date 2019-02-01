using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class DetailsOfCar : DetailsOfVehicle
    {
        private const float k_CarWheelMaxPressure = 32;
        private const int k_CarWheelNumber = 4;
        private Car.eCarColor m_CarColor;
        private Car.eNumberOfDoors m_NumberOfDoors;

        public DetailsOfCar(
            string i_OwnerName,
            string i_OwnerPhone,
            string i_Model,
            string i_PlateNumber,
            Energy i_EnergyType,
            string i_ManufacturerName,
            Vehicle.eVehicleType i_VehicleType,
            Car.eCarColor i_CarColor,
            Car.eNumberOfDoors i_NumberOFDoors)
            : base(
                  i_OwnerName,
                  i_OwnerPhone,
                  i_Model,
                    i_PlateNumber,
                    i_EnergyType,
                    k_CarWheelNumber,
                    i_ManufacturerName,
                    k_CarWheelMaxPressure,
                    i_VehicleType)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOFDoors;
        }

        public static new List<VehicleProperty> GetRequiredProperties()
        {
            List<VehicleProperty> properties = DetailsOfVehicle.GetRequiredProperties();
            properties.Add(new VehicleProperty(typeof(Car.eCarColor), "Color Of Car"));
            properties.Add(new VehicleProperty(typeof(Car.eNumberOfDoors), "Number Of Doors"));

            return properties;
        }

        public override string ToString()
        {
            string DetailsOfCar = string.Format("Car Color: {1}{0}Number Of Doors: {2}{0}", Environment.NewLine, m_CarColor, m_NumberOfDoors);

            return base.ToString() + DetailsOfCar;
        }
    }
}
