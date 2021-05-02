using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public class Sphere : InsertableSolidBody
    {
        private readonly double _radius;

        public Sphere( double density, double radius )
            : base( density )
        {
            _radius = radius;

        }

        public override double GetVolume()
        {
            return 4 / 3 * Math.PI * _radius * _radius * _radius;
        }

        public double GetRadius()
        {
            return _radius;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Radius: {_radius}";
        }
    }
}
