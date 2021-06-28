using System;
using System.Collections.Generic;
using Vehicle.Entities.Passengers;
using Vehicle.Entities.Vehicles;
using Vehicle.Enums;
using Vehicle.Interfaces.Passengers;

namespace Vehicle
{
    class Program
    {
        static void Main( string[] args )
        {
            //initial state
            PoliceCar JhonSmithsPoliceCar = new( 5, MarkOfTheCar.Ford );
            string SouthEastPoliceDepartmentName = "Юго-восточный полицейский участок";
            PoliceMan JhonSmith = new( "Jhon Smith", SouthEastPoliceDepartmentName );
            PoliceMan JimClarke = new( "Jim Clarke", SouthEastPoliceDepartmentName );

            JhonSmithsPoliceCar.AddPassenger( JhonSmith );
            JhonSmithsPoliceCar.AddPassenger( JimClarke );

            Taxi Taxi = new( 2, MarkOfTheCar.Toyota );
            Person Radjah = new( "Раджа Ганди" );
            Racer Shumaher = new( "Михаэль Шумахер", 3 );
            Taxi.AddPassenger( Radjah );
            Taxi.AddPassenger( Shumaher );

            //confilct between police
            JhonSmithsPoliceCar.RemovePassenger( 1 );

            //taxi car appropriation
            Taxi.RemovePassenger( 1 );
            Taxi.AddPassenger( JhonSmith );

            //radjah trying to get taxi back
            try
            {
                Taxi.AddPassenger( Radjah );
            }
            catch ( Exception e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
