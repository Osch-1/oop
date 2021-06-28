using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Entities.Passengers
{
    public sealed class Racer : AbstractPerson, IRacer
    {
        private readonly int _awardsCount;

        public Racer( string name, int awardsCount )
            : base( name )
        {
            _awardsCount = awardsCount;
        }

        public int GetAwardsCount()
        {
            return _awardsCount;
        }
    }
}
