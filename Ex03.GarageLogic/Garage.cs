using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatusInGarage
    {
        InRepair,
        Repaired,
        Paid
    }

    public class Garage
    {
        private Dictionary<string, GarageVehicle> m_DictOfGarageVehicles;

        public Garage()
        {
            m_DictOfGarageVehicles = new Dictionary<string, GarageVehicle>();
        }

        public bool AddVehicleToGarage(Vehicle i_Vehicle)
        {
            if (i_Vehicle == null)
            {
                throw new NullReferenceException("Vehicle undefined, null reference received");
            }

            bool vehicleIsInGarage = m_DictOfGarageVehicles.ContainsKey(i_Vehicle.DetailsOfVehicle.plateNumber);
            GarageVehicle vehicleToAdd;

            if (vehicleIsInGarage)
            {
                ChangeVehicleStatus(i_Vehicle.DetailsOfVehicle.plateNumber, eVehicleStatusInGarage.InRepair);
            }
            else
            {
                vehicleToAdd = new GarageVehicle(i_Vehicle);
                m_DictOfGarageVehicles.Add(i_Vehicle.DetailsOfVehicle.plateNumber, vehicleToAdd);
            }

            return vehicleIsInGarage;
        }

        public void ChangeVehicleStatus(string i_PlateNumber, eVehicleStatusInGarage i_NewVehicleStatus)
        {
            GarageVehicle vehicleToChangeStatus = getVehicleFromDictionary(i_PlateNumber);
            if (vehicleToChangeStatus == null)
            {
                throw new ArgumentException(string.Format("Vehicle with plate number {0} not found ", i_PlateNumber));
            }

            vehicleToChangeStatus.VehicleStatusInGarage = i_NewVehicleStatus;
        }

        public void InflateVehicleWheelsToMax(string i_PlateNumber)
        {
            GarageVehicle vehicleToInflateWheels = getVehicleFromDictionary(i_PlateNumber);
            if (vehicleToInflateWheels == null)
            {
                throw new ArgumentException(string.Format("Vehicle with plate number {0} not found ", i_PlateNumber));
            }

            foreach (Wheel wheel in vehicleToInflateWheels.Vehicle.DetailsOfVehicle.Wheels)
            {
                wheel.inflateWheelToMax();
            }
        }

        public void ChargeElectricVehicle(string i_PlateNumber, float i_ChargeAmount)
        {
            GarageVehicle vehicleToCharge = getVehicleFromDictionary(i_PlateNumber);
            if (vehicleToCharge == null)
            {
                throw new ArgumentException(string.Format("Vehicle with plate number {0} not found ", i_PlateNumber));
            }

            if (!(vehicleToCharge.Vehicle.DetailsOfVehicle.energyType is ElectricBattery))
            {
                throw new ArgumentException("Energy type is incompatible");
            }

                (vehicleToCharge.Vehicle.DetailsOfVehicle.energyType as ElectricBattery).Charge(i_ChargeAmount);
        }

        public void FillFuelInVehicle(string i_PlateNumber, FuelTank.eFuelType i_FuelType, float i_FuelToFill)
        {
            GarageVehicle vehicleToFillFuel = getVehicleFromDictionary(i_PlateNumber);
            if (vehicleToFillFuel == null)
            {
                throw new ArgumentException(string.Format("Vehicle with plate number {0} not found ", i_PlateNumber));
            }

            if (!(vehicleToFillFuel.Vehicle.DetailsOfVehicle.energyType is FuelTank))
            {
                throw new ArgumentException("Energy type is incompatible");
            }

                (vehicleToFillFuel.Vehicle.DetailsOfVehicle.energyType as FuelTank).FillTank(i_FuelToFill, i_FuelType);
        }

        private GarageVehicle getVehicleFromDictionary(string i_PlateNumber)
        {
            GarageVehicle garageVehicle;
            bool vehicleExists = m_DictOfGarageVehicles.TryGetValue(i_PlateNumber, out garageVehicle);
            if (!vehicleExists)
            {
                garageVehicle = null;
            }

            return garageVehicle;
        }

        public string GetVehicleData(string i_PlateNumber)
        {
            GarageVehicle vehicleToGetData = getVehicleFromDictionary(i_PlateNumber);
            if (vehicleToGetData == null)
            {
                throw new ArgumentException(string.Format("Vehicle with plate number {0} not found ", i_PlateNumber));
            }

            return vehicleToGetData.ToString();
        }

        public List<string> GetPlateNumbers()
        {
            List<string> plateNumbers = new List<string>();
            foreach (string plateNumber in m_DictOfGarageVehicles.Keys)
            {
                plateNumbers.Add(plateNumber);
            }

            return plateNumbers;
        }

        public List<string> GetPlateNumbers(eVehicleStatusInGarage i_StatusInGarage)
        {
            List<string> plateNumbers = new List<string>();
            foreach (GarageVehicle vehicleInGarage in m_DictOfGarageVehicles.Values)
            {
                if (vehicleInGarage.VehicleStatusInGarage == i_StatusInGarage)
                {
                    plateNumbers.Add(vehicleInGarage.Vehicle.DetailsOfVehicle.plateNumber);
                }
            }

            return plateNumbers;
        }

        private class GarageVehicle
        {
            private eVehicleStatusInGarage m_VehicleStatusInGarage;
            private Vehicle m_Vehicle;

            public GarageVehicle(Vehicle i_Vehicle)
            {
                m_Vehicle = i_Vehicle;
                m_VehicleStatusInGarage = eVehicleStatusInGarage.InRepair;
            }

            public eVehicleStatusInGarage VehicleStatusInGarage
            {
                get
                {
                    return m_VehicleStatusInGarage;
                }

                set
                {
                    m_VehicleStatusInGarage = value;
                }
            }

            public Vehicle Vehicle
            {
                get
                {
                    return m_Vehicle;
                }
            }

            public override string ToString()
            {
                string vehicleDetails = string.Format(
                                                    "Status in garage: {1}{0}",
                                                    Environment.NewLine,
                                                    VehicleStatusInGarage);

                return Vehicle.ToString() + vehicleDetails;
            }
        }
    }
}
