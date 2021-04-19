using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSimulator
{
    class Program
    {
        static void Main( string[] args )
        {
            Car car = new();
            string command = "";

            while ( command != "Exit" )
            {
                Console.Write( "Enter command: " );
                command = Console.ReadLine();

                string[] values = command.Split( ' ' );
                string action = values[ 0 ];

                if ( action == "Info" )
                {
                    Info( car );
                }

                if ( action == "EngineOn" )
                {
                    if ( EngineOn( car ) )
                    {
                        Console.WriteLine( "Engine turned on" );
                    }
                    else
                    {
                        Console.WriteLine( "Couldnt turn on engine" );
                    }
                }

                if ( action == "EngineOff" )
                {
                    if ( EngineOff( car ) )
                    {
                        Console.WriteLine( "Engine turned off" );
                    }
                    else
                    {
                        if ( car.Gear != Gear.Neutral )
                            Console.WriteLine( "Cant turn off engine, gear isnt set to Neutral" );
                        if ( car.Direction != Direction.OnPlace )
                            Console.WriteLine( "Cant turn off engine, car is moving" );
                    }
                }

                if ( action == "SetGear" )
                {
                    int gear = int.Parse( values[ 1 ] );
                    string prevGear = car.Gear.ToString();

                    if ( car.SetGear( ( Gear )gear ) )
                    {
                        Console.WriteLine( $"Gear switched from {prevGear} to {car.Gear}" );
                    }
                    else
                    {
                        Console.WriteLine( $"Couldnt set gear" );
                    }
                }

                if ( action == "SetSpeed" )
                {
                    int speed = int.Parse( values[ 1 ] );
                    string prevSpeed = car.Speed.ToString();

                    if ( car.SetSpeed( speed ) )
                    {
                        Console.WriteLine( $"Speed switched from {prevSpeed} to {car.Speed}" );
                    }
                    else
                    {
                        Console.WriteLine( $"Couldnt set speed" );
                    }
                }
            }
        }

        static void Info( Car car )
        {
            Console.WriteLine( "Car info: " );

            string isEngineRunning = car.IsEngineRunning ? "is running" : "isnt running";
            Console.WriteLine( $"  Engine {isEngineRunning}" );

            string direction = GetStringifiedDirection( car.Direction );
            Console.WriteLine( $"  Current direction: {direction}" );

            Console.WriteLine( $"  Speed: {car.Speed}" );
            Console.WriteLine( $"  Gear: {car.Gear}" );
        }

        static bool EngineOn( Car car )
        {
            return car.TurnOnEngine();
        }

        static bool EngineOff( Car car )
        {
            return car.TurnOffEngine();
        }

        private static string GetStringifiedDirection( Direction direction )
        {
            switch ( direction )
            {
                case ( Direction.Backward ):
                    return "backward";
                case ( Direction.OnPlace ):
                    return "on place";
                case ( Direction.Forward ):
                    return "forward";
                default:
                    return "Unknown direction";
            }
        }
    }
}
