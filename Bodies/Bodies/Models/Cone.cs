using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Models
{
    public class Cone : SolidBody
    {
        private readonly double _baseRadius;
        private readonly double _height;

        public Cone( double density, double baseRadius, double height )
            : base( density )
        {
            _baseRadius = baseRadius;
            _height = height;
        }

        public override double GetVolume()
        {
            return Math.PI * _baseRadius * _baseRadius * _height / 3;
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
