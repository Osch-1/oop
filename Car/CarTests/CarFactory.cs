using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator;

namespace CarSimulatorTests
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

        public static Car GetMovingBackwardsOnNeutralGearCarWithTenSpeed()
        {
            Car car = GetCarWithTurnedOnEngine();
            car.SetGear( Gear.Reverse );
            car.SetSpeed( 10 );
            car.SetGear( Gear.Neutral );

            return car;
        }

        public static Car GetCarWithFirstGearSet()
        {
            Car car = GetCarWithTurnedOnEngine();
            car.SetGear( Gear.First );

            return car;
        }

        public static Car GetCarWithSecondGearSet()
        {
            Car car = GetCarWithFirstGearSet();
            car.SetSpeed( 30 );
            car.SetGear( Gear.Second );

            return car;
        }

        public static Car GetCarWithThirdGearSet()
        {
            Car car = GetCarWithSecondGearSet();
            car.SetSpeed( 30 );
            car.SetGear( Gear.Third );

            return car;
        }

        public static Car GetCarWithFourthGearSet()
        {
            Car car = GetCarWithThirdGearSet();
            car.SetSpeed( 40 );
            car.SetGear( Gear.Fourth );

            return car;
        }
    }
}
