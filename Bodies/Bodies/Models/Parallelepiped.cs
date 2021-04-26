using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies.Models
{
    public class Parallelepiped : SolidBody
    {
        private readonly double _width;
        private readonly double _height;
        private readonly double _depth;

        public Parallelepiped( double density, double width, double height, double depth )
            : base( density )
        {
            _width = width;
            _height = height;
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
