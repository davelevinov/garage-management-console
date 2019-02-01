using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(DetailsOfMotorcycle i_DetailsOfMotorcycle) : base(i_DetailsOfMotorcycle)
        {
            if (i_DetailsOfMotorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle");
            }
        }

        public enum eMotorcycleLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }
    }
}
