using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Interfaces.Vehicles
{
    public interface IVehicle<TPassenger> : IBasicVehicle where TPassenger : IPerson
    {
        public void AddPassenger( TPassenger passenger );
        public TPassenger GetPassenger( int index );
        public void RemovePassenger( int index );
    }
}
