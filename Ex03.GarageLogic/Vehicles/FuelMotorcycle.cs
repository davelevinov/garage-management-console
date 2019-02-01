using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(DetailsOfFuelMotorcycle i_DetailsOfFuelMotorcycle)
                    : base(i_DetailsOfFuelMotorcycle)
        {
            if (i_DetailsOfFuelMotorcycle == null)
            {
                throw new ArgumentNullException("Fuel Motorcycle");
            }
        }
    }
}
