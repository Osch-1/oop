using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public class Rational
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public int Numerator { get => _numerator; }
        public int Denominator { get => _denominator; }

        public Rational()
        {
            _numerator = 0;
            _denominator = 1;
        }

        public Rational( int value )
        {
            _numerator = value;
            _denominator = 1;
        }

        public Rational( int numerator, int denominator )
        {
            if ( denominator == 0 )
                throw new ArgumentException( "Denominator cant be zero" );

            if ( denominator < 0 && numerator > 0 )
                throw new ArgumentException( "Denominator must be positive if numerator is" );

            if ( numerator == 0 )
                denominator = 1;

            if ( denominator < 0 )
            {
                numerator = Math.Abs( numerator );
                denominator = Math.Abs( denominator );
            }

            int gcd = NumbersUtil.GreatestCommonDivisor( numerator, denominator );

            _numerator = numerator / gcd;
            _denominator = denominator / gcd;
        }

        public double ToDouble()
        {
            return ( double )Numerator / Denominator;
        }

        public Tuple<int, Rational> ToCompoundFraction()
        {
            int intPart = Numerator / Denominator;
            Rational fractionPart = this - intPart;
            return new Tuple<int, Rational>( intPart, fractionPart );
        }

        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }

        #region Операторы сравнения
        public static bool operator ==( Rational r1, Rational r2 )
        {
            return r1.Numerator == r2.Numerator
                    && r1.Denominator == r2.Denominator;
        }
        public static bool operator !=( Rational r1, Rational r2 )
        {
            return r1.Numerator != r2.Numerator
                || r1.Denominator != r2.Denominator;
        }
        public static bool operator <( Rational r1, Rational r2 )
        {
            int commonDenominator = NumbersUtil.LeastCommonMultiple( r1.Denominator, r2.Denominator );
            int firstNumerator = r1.Numerator * commonDenominator;
            int secondNumerator = r2.Numerator * commonDenominator;

            return firstNumerator < secondNumerator;
        }
        public static bool operator >( Rational r1, Rational r2 )
        {
            int commonDenominator = NumbersUtil.LeastCommonMultiple( r1.Denominator, r2.Denominator );
            int firstNumerator = r1.Numerator * commonDenominator;
            int secondNumerator = r2.Numerator * commonDenominator;

            return firstNumerator > secondNumerator;
        }
        public static bool operator <=( Rational r1, Rational r2 )
        {
            return ( r1 < r2 ) || ( r1 == r2 );
        }
        public static bool operator >=( Rational r1, Rational r2 )
        {
            return ( r1 > r2 ) || ( r1 == r2 );
        }
        #endregion

        #region Арифметические операторы
        public static Rational operator +( Rational r ) => r;
        public static Rational operator -( Rational r ) => new( -r.Numerator, r.Denominator );

        public static Rational operator +( Rational rational1, Rational rational2 )
        {
            return new( rational1.Numerator * rational2.Denominator + rational2.Numerator * rational1.Denominator,
                        rational1.Denominator * rational2.Denominator );
        }
        public static Rational operator -( Rational rational1, Rational rational2 )
        {
            return rational1 + ( -rational2 );
        }
        public static Rational operator *( Rational rational1, Rational rational2 )
        {
            return new( rational1.Numerator * rational2.Numerator, rational1.Denominator * rational2.Denominator );
        }
        public static Rational operator /( Rational rational1, Rational rational2 )
        {
            return new( rational1.Numerator * rational2.Denominator, rational1.Denominator * rational2.Numerator );
        }
        #endregion

        public static implicit operator Rational( int value )
        {
            return new Rational( value );
        }

        public override bool Equals( object obj )
        {
            if ( obj is null )
            {
                return false;
            }

            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }

            if ( !( obj is Rational ) )
            {
                return false;
            }

            return this == ( obj as Rational );
        }

        public override int GetHashCode()
        {
            return ( ( double )Numerator / Denominator ).GetHashCode();
        }
    }
}
