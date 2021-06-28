using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Interfaces.Passengers;

namespace Vehicle.Entities.Passengers
{
    public sealed class PoliceMan : AbstractPerson, IPoliceMan
    {
        private readonly string _department;

        public PoliceMan( string name, string department )
            : base( name )
        {
            _department = department;
        }

        public string GetDepartmentName()
        {
            return _department;
        }
    }
}
