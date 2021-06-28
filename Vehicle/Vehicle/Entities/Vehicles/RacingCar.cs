using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Entities.Vehicles
{
    public class RacingCar : AbstractCar<IRacer>
    {
        public RacingCar( int placesCount )
            : base( placesCount )
        {
        }
    }
}
