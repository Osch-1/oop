using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSimulator
{
    class Program
    {
        static void Main( string[] args )
        {
            AbstractCar car = new Car();
            ICarController carController = new CarController( car );
            string command = "";

            while ( command != "Exit" )
            {
                Console.Write( "Enter command: " );
                command = Console.ReadLine();

                string[] values = command.Split( ' ' );
                string action = values[ 0 ];

                if ( action == "Info" )
                {
                    carController.Info();
                }

                if ( action == "EngineOn" )
                {
                    carController.EngineOn();
                    Console.WriteLine( "Engine turned on" );
                }

                if ( action == "EngineOff" )
                {
                    if ( carController.EngineOff() )
                        Console.WriteLine( "Engine turned off" );
                    else
                        Console.WriteLine( "Couldn't turn engine off" );
                }

                if ( action == "SetSpeed" )
                {
                    int speed = int.Parse( values[ 1 ] );
                    string prevSpeed = car.Speed.ToString();

                    if ( carController.SetSpeed( speed ) )
                    {
                        Console.WriteLine( $"Speed switched from {prevSpeed} to {car.Speed}" );
                    }
                    else
                    {
                        Console.WriteLine( $"Couldnt set speed" );
                    }
                }

                if ( action == "SetGear" )
                {
                    int gear = int.Parse( values[ 1 ] );
                    string prevGear = car.Gear.ToString();

                    if ( carController.SetGear( ( Gear )gear ) )
                    {
                        Console.WriteLine( $"Gear switched from {prevGear} to {car.Gear}" );
                    }
                    else
                    {
                        Console.WriteLine( $"Couldnt set gear" );
                    }
                }
            }
        }
    }
}
