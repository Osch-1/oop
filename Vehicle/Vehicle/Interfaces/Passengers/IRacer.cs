using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Interfaces.Passengers
{
    public interface IRacer : IPerson
    {
        public abstract int GetAwardsCount();
    }
}
