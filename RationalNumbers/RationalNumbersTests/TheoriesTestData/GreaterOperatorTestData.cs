using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class GreaterOperatorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 1, 2 ), new Rational( 2, 3 ), false },
            new object[] { new Rational( 2, 3 ), new Rational( 1, 2 ), true },
            new object[] { new Rational( 2, 3 ), new Rational( 2, 3 ), false },
            new object[] { new Rational( 0 ), new Rational( 2, 3 ), false },
            new object[] { new Rational( -2, 3 ), new Rational( 2, 3 ), false },
            new object[] { new Rational( -2, 3 ), new Rational( -1, 2 ), false },
            new object[] { new Rational( -2, 3 ), 0, false }
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
