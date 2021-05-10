using System.Collections;
using System.Collections.Generic;
using RationalNumbers;

namespace RationalNumbersTests
{
    public class NotEqualsOperatorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { new Rational( 1, 2 ), new Rational( 1, 2 ), false },
            new object[] { new Rational( 1, 2 ), new Rational( -1, 2 ), true },
            new object[] { new Rational( 1, 2 ), new Rational( 2, 4 ), false },
            new object[] { new Rational( -1, 2 ), new Rational( 1, 2 ), true }
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