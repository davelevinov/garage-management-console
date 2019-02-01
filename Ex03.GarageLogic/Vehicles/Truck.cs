using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        public Truck(DetailsOfTruck i_DetailsOfTruck) : base(i_DetailsOfTruck)
        {
            if(i_DetailsOfTruck == null)
            {
                throw new ArgumentNullException("Truck");
            }
        }
    }
}
