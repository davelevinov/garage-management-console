using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        public FuelTruck(DetailsOfFuelTruck i_DetailsOfFuelTruck)
            : base(i_DetailsOfFuelTruck)
        {
            if (i_DetailsOfFuelTruck == null)
            {
                throw new NullReferenceException("Fuel Truck");
            }
        }
    }
}
