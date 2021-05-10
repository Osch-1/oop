using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class BinaryMinusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 27, 13 ), new Rational( 13, 27 ), new Rational( 560, 351 ) },
            new object[] { new Rational( 27, 13 ), new Rational( -13, 27 ), new Rational( 898, 351 ) },
            new object[] { new Rational( -11, 22 ), new Rational( 1, 3 ), new Rational( -5, 6 ) },
            new object[] { new Rational( -3, 7 ), 2, new Rational( -17, 7 ) },
            new object[] { 2, new Rational( -3, 7 ), new Rational( 17, 7 ) },
            new object[] { 0, new Rational( -3, 7 ), new Rational( 3, 7 ) },
            new object[] { 0, new Rational( 0 ), new Rational( 0, 1 ) },
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
