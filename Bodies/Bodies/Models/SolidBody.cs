using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Interfaces;

namespace Bodies.Models
{
    public abstract class SolidBody : IBody
    {
        private readonly double _density;

        public SolidBody( double density )
        {
            _density = density;
        }

        public List<Compound> GetParents()
        {
            throw new NotImplementedException();
        }

        public bool SetParent( Compound parent )
        {
            throw new NotImplementedException();
        }

        public virtual double GetVolume()
        {
            return 0;
        }

        public double GetDensity()
        {
            return _density;
        }

        public double GetMass()
        {
            return GetVolume() * _density;
        }

        public override string ToString()
        {
            return $"Volume: {GetVolume()}, Mass: {GetMass()}, Density: {GetDensity()}";
        }
    }
}
