using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class MultiplicationOperatorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 3, 2 ), new Rational( 7, 13 ), new Rational( 21, 26 ) },
            new object[] { new Rational( 3, 2 ), new Rational( 2, 3 ), new Rational( 1, 1 ) },
            new object[] { new Rational( 3, 2 ), 2, new Rational( 3, 1 ) },
            new object[] { 2, new Rational( 3, 2 ), new Rational( 3, 1 ) },
            new object[] { new Rational( 3, 2 ), 0, new Rational( 0, 1 ) },
            new object[] { new Rational( -3, 2 ), new Rational( 7, 13 ), new Rational( -21, 26 ) }
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
