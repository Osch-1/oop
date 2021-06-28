using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Interfaces.Vehicles
{
    public interface ICar<TPassenger> where TPassenger : IPerson
    {
        public abstract MarkOfTheCar GetMarkOfTheCar();
    }
}
