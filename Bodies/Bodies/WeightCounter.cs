using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public static class WeightCounter
    {
        const double _g = 9.81;
        const int _waterDensity = 1000;

        public static double CountInWaterWeight( Body body )
        {
            return _g * body.GetVolume() * ( body.GetDensity() - _waterDensity );
        }
    }
}
