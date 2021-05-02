using System;
using System.Collections.Generic;

namespace Bodies
{
    public abstract class InsertableSolidBody : InsertableBody
    {
        private readonly double _density = 0;

        public InsertableSolidBody( double density )
        {
            if ( density >= 0 )
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
