using System.IO;
using System;
namespace RationalNumbers
{
    class A
    {
        public void DoSmth( string arg )
        {
            Console.WriteLine( arg.GetType() );
        }

        public void DoSmth<T>( T arg )
        {
            Console.WriteLine( arg.GetType() );
        }
    }

    class Program
    {
        static void Main( string[] args )
        {
            A aInstance = new();
            aInstance.DoSmth<string>( "asd" );
            aInstance.DoSmth( "asd" );


        }
    }
}
