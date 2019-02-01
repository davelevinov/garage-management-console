using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBattery : Energy
    {        
        // default creation of battery is to be full
        public ElectricBattery(float i_BatteryCapacity, float i_RemainingBatteryTime) : base(i_BatteryCapacity, i_RemainingBatteryTime)
        {
        }

        public void Charge(float i_ChargeAmountInMinutes)
        {
            float chargeAmountInHours = i_ChargeAmountInMinutes / 60;
            FillEnergy(chargeAmountInHours);
        }

        public override string ToString()
        {
            string DetailsOfElectric = string.Format("Energy Type: Electric{0}", Environment.NewLine);

            return base.ToString() + DetailsOfElectric;
        }
    }
}
