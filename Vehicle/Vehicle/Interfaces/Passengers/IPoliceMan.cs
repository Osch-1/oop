using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Interfaces.Passengers
{
    public interface IPoliceMan : IPerson
    {
        public abstract string GetDepartmentName();
    }
}
