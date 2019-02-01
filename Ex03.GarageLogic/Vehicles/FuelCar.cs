using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public FuelCar(DetailsOfFuelCar i_DetailsOfFuelCar)
      : base(i_DetailsOfFuelCar)
        {
            if (i_DetailsOfFuelCar == null)
            {
                throw new ArgumentNullException("Fuel Car");
            }
        }
    }
}
