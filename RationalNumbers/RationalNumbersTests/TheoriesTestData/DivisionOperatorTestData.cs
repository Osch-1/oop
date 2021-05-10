using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class DivisionOperatorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 3, 2 ), new Rational( 7, 13 ), new Rational( 39, 14 ) },
            new object[] { new Rational( 3, 2 ), new Rational( 2, 3 ), new Rational( 9, 4 ) },
            new object[] { new Rational( 3, 2 ), 2, new Rational( 3, 4 ) },
            new object[] { 2, new Rational( 3, 2 ), new Rational( 4, 3 ) },
            new object[] { new Rational( -3, 2 ), new Rational( 7, 13 ), new Rational( -39, 14 ) },
            new object[] { 0, new Rational( 3, 2 ), new Rational( 0, 1 ) },
            new object[] { new Rational( 7, 13 ), new Rational( 7, 4 ), new Rational( 4, 13 ) },
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
