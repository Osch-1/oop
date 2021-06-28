using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Entities.Passengers
{
    public abstract class AbstractPerson : IPerson
    {
        private readonly string _name;

        public AbstractPerson( string name )
        {
            _name = name;
        }

        public virtual string GetName()
        {
            return _name;
        }
    }
}
