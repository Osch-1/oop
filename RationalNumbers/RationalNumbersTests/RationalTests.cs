using System;
using System.Collections;
using System.Collections.Generic;
using RationalNumbers;
using RationalNumbersTests.TheoriesTestData;
using Xunit;

namespace RationalNumbersTests
{
    public class RationalTests
    {
        [Fact]
        public void Rational_Constructor_NoParams_CreatesZeroToOneNumber()
        {
            //Arrange & act
            Rational num = new();

            //Assert
            Assert.Equal( 0, num.Numerator );
            Assert.Equal( 1, num.Denominator );
        }

        [Fact]
        public void Rational_Constructor_IntValue_CreatesCorrectNumber()
        {
            //Arrange & act
            Rational numerator = new( 10 );
            Rational denominator = new( -10 );

            //Assert
            Assert.Equal( 10, numerator.Numerator );
            Assert.Equal( 1, numerator.Denominator );

            Assert.Equal( -10, denominator.Numerator );
            Assert.Equal( 1, denominator.Denominator );
        }

        [Fact]
        public void Rational_Constructor_RelativePrimeNumeratorAndDenominator_CreatesCorrectNumber()
        {
            //Arrange & act
            Rational num = new( 2, 3 );

            //Assert
            Assert.Equal( 2, num.Numerator );
            Assert.Equal( 3, num.Denominator );
        }

        [Fact]
        public void Rational_Constructor_ZeroEqualsDenominator_ThrowsException()
        {
            //Arrange & Act 
            static void act() => new Rational( 2, 0 );

            //Assert
            Assert.Throws<ArgumentException>( act );
        }

        [Fact]
        public void Rational_Constructor_NegativeDenominator_ThrowsException()
        {
            //Arrange & Act 
            static void act() => new Rational( 2, -3 );

            //Assert
            Assert.Throws<ArgumentException>( act );
        }

        [Fact]
        public void Rational_Constructor_NotRelativePrimeNumbers_ReturnsNonreducibleFraction()
        {
            //Arrange
            int numerator = 25, denominator = 100;

            //Act
            Rational rational = new( numerator, denominator );

            //Assert
            Assert.Equal( 1, rational.Numerator );
            Assert.Equal( 4, rational.Denominator );
        }

        [Fact]
        public void Rational_Constructor_NotRelativePrimeNumbersWithNegativeNumerator_ReturnsNonreducibleFraction()
        {
            //Arrange
            int numerator = -24, denominator = 56;

            //Act
            Rational rational = new( numerator, denominator );

            //Assert
            Assert.Equal( -3, rational.Numerator );
            Assert.Equal( 7, rational.Denominator );
        }

        [Fact]
        public void Rational_Constructor_NegativeNumeratorAndDenominator_ReturnsCorrectValue()
        {
            //Arrange
            int numerator = -24, denominator = -56;

            //Act
            Rational rational = new( numerator, denominator );

            //Assert
            Assert.Equal( 3, rational.Numerator );
            Assert.Equal( 7, rational.Denominator );
        }

        [Fact]
        public void Rational_Constructor_ZeroNumeratorAndNegativeDenominator_ReturnsCorrectValue()
        {
            //Arrange
            int numerator = 0, denominator = -56;

            //Act
            Rational rational = new( numerator, denominator );

            //Assert
            Assert.Equal( 0, rational.Numerator );
            Assert.Equal( 1, rational.Denominator );
        }

        [Theory]
        [InlineData( 3, 4, .75 )]
        [InlineData( -3, 4, -0.75 )]
        [InlineData( 21, 56, .375 )]
        public void Rational_ToDouble_ReturnsRatioOfNumeratorToDenominator( int numerator, int denominator, double ratio )
        {
            //Arrange
            Rational rational = new( numerator, denominator );

            //Act
            var res = rational.ToDouble();

            //Assert
            Assert.Equal( ratio, res );
        }

        [Fact]
        public void Rational_UnaryPlus_ReturnsSameValue()
        {
            //Arrange
            Rational rational = new( 3, 2 );

            //Act
            var res = +rational;

            //Assert
            Assert.Equal( 3, res.Numerator );
            Assert.Equal( 2, res.Denominator );
        }

        [Theory, ClassData( typeof( UnaryMinusTestData ) )]
        public void Rational_UnaryMinus_ReturnsNumberWithOppositeNumeratorSign( int numerator, int denominator, Rational rat )
        {
            //Arrange
            Rational rational = new( numerator, denominator );

            //Act
            var res = -rational;

            //Assert
            Assert.Equal( rat.Numerator, res.Numerator );
            Assert.Equal( rat.Denominator, res.Denominator );
        }

        [Theory, ClassData( typeof( EqualsOperatorTestData ) )]
        public void Rational_EqualsOperator_ReturnsSum( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 == rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( NotEqualsOperatorTestData ) )]
        public void Rational_NotEqualsOperator_ReturnsSum( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 != rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( BinaryPlusTestData ) )]
        public void Rational_BinaryPlus_ReturnsSum( Rational rational1, Rational rational2, Rational result )
        {
            //Arrange & Act
            var sum = rational1 + rational2;

            //Assert
            Assert.Equal( result, sum );
        }

        [Theory, ClassData( typeof( BinaryMinusTestData ) )]
        public void Rational_BinaryMinus_ReturnsDifference( Rational rational1, Rational rational2, Rational result )
        {
            //Arrange & Act
            var diff = rational1 - rational2;

            //Assert
            Assert.Equal( result, diff );
        }

        [Theory]
        [InlineData( 3, 3, 1 )]
        [InlineData( -3, -3, 1 )]
        [InlineData( 0, 0, 1 )]
        public void Rational_ImplicitFromInt32Constructor_ReturnsCorrectRational( int value, int numerator, int denominator )
        {
            //Arrange & Act
            Rational rational = value;

            //Assert
            Assert.Equal( numerator, rational.Numerator );
            Assert.Equal( denominator, rational.Denominator );
        }

        [Theory, ClassData( typeof( MultiplicationOperatorTestData ) )]
        public void Rational_MultiplicationOperator_ReturnsMultiplication( Rational rational1, Rational rational2, Rational result )
        {
            //Arrange & Act
            var mult = rational1 * rational2;

            //Assert
            Assert.Equal( result, mult );
        }

        [Theory, ClassData( typeof( DivisionOperatorTestData ) )]
        public void Rational_DivisionOperator_ReturnsQuotient( Rational rational1, Rational rational2, Rational result )
        {
            //Arrange & Act
            var quotient = rational1 / rational2;

            //Assert
            Assert.Equal( result, quotient );
        }

        [Theory, ClassData( typeof( LessOperatorTestData ) )]
        public void Rational_LessOperator_ReturnsCorrectResult( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 < rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( GreaterOperatorTestData ) )]
        public void Rational_GreaterOperator_ReturnsCorrectResult( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 > rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( LessOrEqualsOperatorTestData ) )]
        public void Rational_LessOrEqualsOperator_ReturnsCorrectResult( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 <= rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( GreaterOrEqualsOperatorTestData ) )]
        public void Rational_GreaterOrEqualsOperator_ReturnsCorrectResult( Rational rational1, Rational rational2, bool expectedResult )
        {
            //Arrange & Act
            var result = rational1 >= rational2;

            //Assert
            Assert.Equal( expectedResult, result );
        }

        [Theory, ClassData( typeof( ToCompoundFractionTestData ) )]
        public void Rational_ToCompoundFraction_ReturnsCorrectResult( Rational rational, int intPart, Rational fractPart )
        {
            //Arrange & Act
            var result = rational.ToCompoundFraction();

            //Assert
            Assert.Equal( intPart, result.Item1 );
            Assert.Equal( fractPart, result.Item2 );
        }
    }
}
