using System.Collections;
using System.Collections.Generic;
using RationalNumbers;

namespace RationalNumbersTests.TheoriesTestData
{
    public class UnaryMinusTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { 3, 2, new Rational( -3, 2 ) },
            new object[] { -3, 2, new Rational( 3, 2 ) },
            new object[] { 0, 2, new Rational( 0, 2 ) },
            new object[] { 3, 1, new Rational( -3 ) },
            new object[] { 0, 1, new Rational() }
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
