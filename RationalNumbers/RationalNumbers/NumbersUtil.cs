using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public static class NumbersUtil
    {
        public static int GreatestCommonDivisor( int num1, int num2 )
        {
            num1 = Math.Abs( num1 );
            num2 = Math.Abs( num2 );

            if ( num1 == 0 || num2 == 0 || num1 == 1 || num2 == 1 )
                return 1;

            if ( num1 == num2 )
                return num1;

            while ( num2 > 0 )
            {
                int temp = num1 % num2;
                num1 = num2;
                num2 = temp;
            }

            return num1;
        }

        public static int LeastCommonMultiple( int num1, int num2 )
        {
            return num1 / GreatestCommonDivisor( num1, num2 ) * num2;
        }
    }
}
