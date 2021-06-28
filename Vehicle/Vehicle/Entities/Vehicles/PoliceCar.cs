using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Entities.Vehicles
{
    public class PoliceCar : AbstractCar<IPoliceMan>
    {
        public PoliceCar( int placesCount, MarkOfTheCar markOfTheCar )
            : base( placesCount, markOfTheCar )
        {
        }
    }
}
