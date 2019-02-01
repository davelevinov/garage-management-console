using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public Car(DetailsOfCar i_DetailsOfCar) : base(i_DetailsOfCar)
        {
            if (i_DetailsOfCar == null)
            {
                throw new ArgumentNullException("Car");
            }
        }

        public enum eCarColor
        {
            Red = 1,
            Yellow = 2,
            Black = 3,
            Silver = 4
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }
    }
}
