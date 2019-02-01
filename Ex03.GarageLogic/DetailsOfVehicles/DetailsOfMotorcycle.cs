using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class DetailsOfMotorcycle : DetailsOfVehicle
    {
        private const float k_MotorcycleWheelMaxPressure = 30;
        private const int k_MotorcycleWheelNumber = 2;
        private Motorcycle.eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;

        public DetailsOfMotorcycle(
            string i_OwnerName, 
            string i_OwnerPhone, 
            string i_Model, 
            string i_PlateNumber, 
            Energy i_EnergyType,
            string i_ManufacturerName, 
            Vehicle.eVehicleType i_VehicleType, 
            Motorcycle.eMotorcycleLicenseType i_LicenseType, 
            int i_EngineVolume) 
            : base(
                  i_OwnerName, 
                  i_OwnerPhone, 
                  i_Model,
                  i_PlateNumber, 
                  i_EnergyType, 
                  k_MotorcycleWheelNumber,
                  i_ManufacturerName, 
                  k_MotorcycleWheelMaxPressure, 
                  i_VehicleType)
        {
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;
        }

        public static new List<VehicleProperty> GetRequiredProperties()
        {
            List<VehicleProperty> properties = DetailsOfVehicle.GetRequiredProperties();
            properties.Add(new VehicleProperty(typeof(Motorcycle.eMotorcycleLicenseType), "License Type"));
            properties.Add(new VehicleProperty(typeof(int), "Engine Volume"));

            return properties;
        }

        public Motorcycle.eMotorcycleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public override string ToString()
        {
            string detailsOfMotorcycle = string.Format("License Type: {1}{0}Engine Volume: {2}{0}", Environment.NewLine, m_LicenseType, m_EngineVolume);

            return base.ToString() + detailsOfMotorcycle;
        }
    }
}
