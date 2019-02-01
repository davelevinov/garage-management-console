using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class DetailsOfTruck : DetailsOfVehicle
    {
        private const float k_TruckWheelMaxPressure = 28;
        private const int k_TruckWheelNumber = 12;        
        private readonly float r_MaxLoad;
        private bool m_IsCarryingHazardousMaterials;

        public DetailsOfTruck(
            string i_OwnerName, 
            string i_OwnerPhone, 
            string i_Model, 
            string i_PlateNumber, 
            Energy i_EnergyType,
            string i_ManufacturerName, 
            Vehicle.eVehicleType i_VehicleType,
            float i_MaxLoad, 
            bool i_IsCarryingHazardousMaterials) 
            : base(
                  i_OwnerName, 
                  i_OwnerPhone, 
                  i_Model,
                  i_PlateNumber, 
                  i_EnergyType, 
                  k_TruckWheelNumber,
                  i_ManufacturerName, 
                  k_TruckWheelMaxPressure, 
                  i_VehicleType)
        {
            r_MaxLoad = i_MaxLoad;
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
        }

        public static new List<VehicleProperty> GetRequiredProperties()
        {
            List<VehicleProperty> properties = DetailsOfVehicle.GetRequiredProperties();
            properties.Add(new VehicleProperty(typeof(float), "Maximum Load Weight"));
            properties.Add(new VehicleProperty(typeof(bool), "Carrying Hazardous Materials"));

            return properties;
        }

        public override string ToString()
        {
            string detailsOfTruck = string.Format("Truck Max Load: {1}{0}Is Carrying Hazardous Materials: {2}{0}", Environment.NewLine, r_MaxLoad, m_IsCarryingHazardousMaterials);

            return base.ToString() + detailsOfTruck;
        }

        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
        }

        public float MaxLoad
        {
            get
            {
                return r_MaxLoad;
            }
        }
    }
}
