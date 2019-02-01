    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public static Vehicle MakeVehicle(Vehicle.eVehicleType i_VehicleType, DetailsOfVehicle i_DetailsOfVehicle)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.FuelCar:
                    newVehicle = new FuelCar(i_DetailsOfVehicle as DetailsOfFuelCar);
                    break;
                case Vehicle.eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar(i_DetailsOfVehicle as DetailsOfElectricCar);
                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_DetailsOfVehicle as DetailsOfElectricMotorcycle);
                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(i_DetailsOfVehicle as DetailsOfFuelMotorcycle);
                    break;
                case Vehicle.eVehicleType.Truck:
                    newVehicle = new FuelTruck(i_DetailsOfVehicle as DetailsOfFuelTruck);
                    break;
            }

            return newVehicle;
        }
    }
}
