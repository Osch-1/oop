using System;
using System.Collections.Generic;

namespace Bodies
{
    public abstract class InsertableSolidBody : InsertableBody
    {
        private readonly double _density;

        public InsertableSolidBody( double density )
        {
            _density = density;
        }

        public override double GetVolume()
        {
            throw new NotImplementedException();
        }

        public override double GetDensity()
        {
            return _density;
        }

        public override double GetMass()
        {
            return GetVolume() * _density;
        }
    }
}
