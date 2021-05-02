using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public abstract class Body
    {
        public virtual double GetVolume()
        {
            throw new NotImplementedException();
        }

        public virtual double GetDensity()
        {
            throw new NotImplementedException();
        }

        public virtual double GetMass()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Volume: {GetVolume()}, Mass: {GetMass()}, Density: {GetDensity()}";
        }
    }
}
