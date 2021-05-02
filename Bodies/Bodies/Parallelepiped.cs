using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public class Parallelepiped : InsertableSolidBody
    {
        private readonly double _width = 0;
        private readonly double _height = 0;
        private readonly double _depth = 0;

        public Parallelepiped( double density, double width, double height, double depth )
            : base( density )
        {
            if ( width >= 0 )
                _width = width;
            if ( height >= 0 )
                _height = height;
            if ( depth >= 0 )
                _depth = depth;
        }

        public override double GetVolume()
        {
            return _width * _height * _depth;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetDepth()
        {
            return _depth;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Width: {_width}, Height: {_height}, Depth: {_depth}";
        }
    }
}
