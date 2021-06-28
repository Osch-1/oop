using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;
using Vehicle.Interfaces.Passengers;
using Vehicle.Interfaces.Vehicles;

namespace Vehicle.Entities.Vehicles
{
    public abstract class AbstractCar<TPassenger> : AbstractVehicle<TPassenger>, ICar<TPassenger> where TPassenger : IPerson
    {
        private readonly MarkOfTheCar _markOfTheCar = MarkOfTheCar.Unknown;

        public AbstractCar( int placesCount )
            : base( placesCount )
        {
        }

        public AbstractCar( int placesCount, MarkOfTheCar markOfTheCar )
            : base( placesCount )
        {
            _markOfTheCar = markOfTheCar;
        }

        public MarkOfTheCar GetMarkOfTheCar()
        {
            return _markOfTheCar;
        }
    }
}
