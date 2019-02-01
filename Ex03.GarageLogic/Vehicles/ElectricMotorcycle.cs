using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(DetailsOfElectricMotorcycle i_DetailsOfElectricMotorcycle)
                    : base(i_DetailsOfElectricMotorcycle)
        {
            if (i_DetailsOfElectricMotorcycle == null)
            {
                throw new ArgumentNullException("Electric Motorcycle");
            }
        }
    }
}
