using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public class Cylinder : InsertableSolidBody
    {
        private readonly double _baseRadius = 0;
        private readonly double _height = 0;

        public Cylinder( double density, double height, double baseRadius )
            : base( density )
        {
            if ( height >= 0 )
                _height = height;
            if ( baseRadius >= 0 )
                _baseRadius = baseRadius;
        }

        public override double GetVolume()
        {
            return Math.PI * _baseRadius * _baseRadius * _height;
        }

        public double GetBaseRadius()
        {
            return _baseRadius;
        }

        public double GetHeight()
        {
            return _height;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Base radius: {_baseRadius}, Height: {_height}";
        }
    }
}
