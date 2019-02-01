using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(DetailsOfElectricCar i_DetailsOfElectricCar)
            : base(i_DetailsOfElectricCar)
        {
            if (i_DetailsOfElectricCar == null)
            {
                throw new ArgumentNullException("Electric Car");
            }
        }
    }
}
