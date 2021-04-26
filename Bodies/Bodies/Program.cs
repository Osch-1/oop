using System;
using Bodies.Models;

namespace Bodies
{
    class Program
    {
        static void Main( string[] args )
        {
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound childCompound = new();
            Cylinder cylinder = new( 10, 10, 10 );

            //act
            containerCompound.AddChildBody( cone );
            containerCompound.AddChildBody( childCompound );
            childCompound.AddChildBody( cylinder );

            Console.WriteLine( containerCompound.GetVolume() );
            Console.WriteLine( containerCompound.GetMass() );
            Console.WriteLine( containerCompound.GetDensity() );
        }
    }
}
