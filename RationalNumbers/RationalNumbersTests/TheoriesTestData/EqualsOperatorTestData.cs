using System.Collections;
using System.Collections.Generic;
using RationalNumbers;

namespace RationalNumbersTests
{
    public class EqualsOperatorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 1, 2 ), new Rational( 1, 2 ), true },
            new object[] { new Rational( 1, 2 ), new Rational( -1, 2 ), false },
            new object[] { new Rational( 1, 2 ), new Rational( 2, 4 ), true },
            new object[] { new Rational( -1, 2 ), new Rational( 1, 2 ), false }
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