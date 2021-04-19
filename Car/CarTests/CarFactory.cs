using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator;

namespace CarTests
{
    public static class CarFactory
    {
        public static Car GetCarWithTurnedOnEngine()
        {
            Car car = new();
            car.TurnOnEngine();

            return car;
        }

        public static Car GetCarWithFirstGearAndTenSpeed()
        {
            Car car = GetCarWithTurnedOnEngine();
            car.SetGear( Gear.First );
            car.SetSpeed( 10 );

            return car;
        }

        public static Car GetMovingBackwardsCarWithTenSpeed()
        {
            Car car = GetCarWithTurnedOnEngine();
            car.SetGear( Gear.Reverse );
            car.SetSpeed( 10 );
            car.SetGear( Gear.Neutral );

            return car;
        }
    }
}
