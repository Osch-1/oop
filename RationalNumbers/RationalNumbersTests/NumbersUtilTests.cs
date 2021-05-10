using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalNumbers;
using Xunit;

namespace RationalNumbersTests
{
    public class NumbersUtilTests
    {
        [Fact]
        public void NumbersUtil_GreatestCommonDivisor_Zeros_Returns1()
        {
            //Arrange
            int num1 = 0, num2 = 0;

            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 1, gcd );
        }

        [Fact]
        public void NumbersUtil_GreatestCommonDivisor_PositiveNumbers_ReturnsCorrectValue()
        {
            //Arrange
            int num1 = 10, num2 = 5;

            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 5, gcd );
        }

        [Fact]
        public void NumbersUtil_GreatestCommonDivisor_NegativeNumbers_ReturnsCorrectValue()
        {
            //Arrange
            int num1 = -10, num2 = -5;

            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 5, gcd );
        }

        [Fact]
        public void NumbersUtil_GreatestCommonDivisor_DifferentSignNumbers_ReturnsCorrectValue()
        {
            //Arrange
            int num1 = -10, num2 = 5;

            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 5, gcd );
        }

        [Theory]
        [InlineData( -10, 0 )]
        [InlineData( 10, 0 )]
        public void NumbersUtil_GreatestCommonDivisor_OneNumberIsZero_ReturnsCorrectValue( int num1, int num2 )
        {
            //Arrange

            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 1, gcd );
        }

        [Fact]
        public void NumbersUtil_GreatestCommonDivisor_RelativePrimes_ReturnsCorrectValue()
        {
            //Arrange
            int num1 = 2, num2 = 3;
            //Act
            var gcd = NumbersUtil.GreatestCommonDivisor( num1, num2 );

            //Assert
            Assert.Equal( 1, gcd );
        }
    }
}
