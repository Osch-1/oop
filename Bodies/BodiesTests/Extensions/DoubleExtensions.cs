using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodiesTests
{
    public static class DoubleExtensions
    {
        private static readonly double _epsilon = 0.001;
        public static bool AreEqual( this double val1, double val2 )
        {
            return Math.Abs( val1 - val2 ) <= _epsilon;
        }
    }
}
