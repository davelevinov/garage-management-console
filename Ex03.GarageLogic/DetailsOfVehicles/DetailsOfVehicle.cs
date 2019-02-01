using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class DetailsOfVehicle
    {
        private readonly string r_Model;
        private readonly string r_PlateNumber;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private List<Wheel> m_Wheels;
        private Energy m_EnergyType;
        private int m_NumberOfWheels;
        private Vehicle.eVehicleType m_VehicleType;

        public DetailsOfVehicle(
            string i_OwnerName,
            string i_OwnerPhone,
            string i_Model,
            string i_PlateNumber,
            Energy i_EnergyType,
          int i_NumberOfWheels,
            string i_ManufacturerName,
            float i_MaxPressure,
            Vehicle.eVehicleType i_VehicleType)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            r_Model = i_Model;
            r_PlateNumber = i_PlateNumber;
            m_EnergyType = i_EnergyType;
            m_NumberOfWheels = i_NumberOfWheels;
            m_VehicleType = i_VehicleType;
            m_Wheels = new List<Wheel>();
            setVehicleWheels(i_ManufacturerName, i_MaxPressure, i_NumberOfWheels);
        }

        private void setVehicleWheels(string i_ManufacturerName, float i_MaxPressure, int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturerName, i_MaxPressure));
            }
        }

        public override string ToString()
        {
            string detailsOfVehicle = string.Format(
                                  "Owner name: {1}{0}Owner phone: {2}{0}Model name: {3}{0}Plate Number: {4}{0}Number Of Wheels: {5}{0}",
                                  Environment.NewLine,
                                  m_OwnerName,
                                  m_OwnerPhone,
                                  r_Model, 
                                  r_PlateNumber, 
                                  m_NumberOfWheels);

            return detailsOfVehicle + m_Wheels[0].ToString() + energyType.ToString();
        }

        public string ownerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string ownerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
        }

        public string model
        {
            get
            {
                return r_Model;
            }
        }

        public string plateNumber
        {
            get
            {
                return r_PlateNumber;
            }
        }

        public Energy energyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        public Vehicle.eVehicleType vehicleType
        {
            get
            {
                return m_VehicleType;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return m_NumberOfWheels;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public static List<VehicleProperty> GetRequiredProperties()
        {
            List<VehicleProperty> properties = new List<VehicleProperty>();
            properties.Add(new VehicleProperty(typeof(string), "Owner Name"));
            properties.Add(new VehicleProperty(typeof(string), "Owner Phone"));
            properties.Add(new VehicleProperty(typeof(string), "Vehicle Model"));
            properties.Add(new VehicleProperty(typeof(string), "Plate Number"));
            properties.Add(new VehicleProperty(typeof(string), "Wheels Manufacturer"));

            return properties;
        }
    }
}
