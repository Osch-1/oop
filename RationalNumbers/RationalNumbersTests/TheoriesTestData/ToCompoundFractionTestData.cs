using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class ToCompoundFractionTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 1, 2 ), 0, new Rational( 1, 2 ) },
            new object[] { 0, 0, new Rational( 0, 1 ) },
            new object[] { new Rational( -1, 2 ), 0, new Rational( -1, 2 ) },
            new object[] { new Rational( 12, 5 ), 2, new Rational( 2, 5 ) },
            new object[] { new Rational( -12, 5 ), -2, new Rational( -2, 5 ) },
            new object[] { new Rational( -10, 5 ), -2, new Rational( 0, 1 ) },
            new object[] { new Rational( 10, 5 ), 2, new Rational( 0, 1 ) }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
