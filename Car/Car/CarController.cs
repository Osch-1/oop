using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class CarController : ICarController
    {
        private readonly AbstractCar _car;

        public CarController( AbstractCar car )
        {
            _car = car;
        }

        public bool EngineOff()
        {
            return _car.TurnOffEngine();
        }

        public bool EngineOn()
        {
            return _car.TurnOnEngine();
        }

        public void Info()
        {
            Console.WriteLine( "Car info: " );

            string isEngineRunning = _car.IsEngineRunning ? "is running" : "isnt running";
            Console.WriteLine( $"  Engine {isEngineRunning}" );

            string direction = GetStringifiedDirection( _car.Direction );
            Console.WriteLine( $"  Current direction: {direction}" );

            Console.WriteLine( $"  Speed: {_car.Speed}" );
            Console.WriteLine( $"  Gear: {_car.Gear}" );
        }

        public bool SetGear( Gear gear )
        {
            return _car.SetGear( gear );
        }

        public bool SetSpeed( int speed )
        {
            return _car.SetSpeed( speed );
        }

        private string GetStringifiedDirection( Direction direction )
        {
            return direction switch
            {
                ( Direction.Backward ) => "backward",
                ( Direction.OnPlace ) => "on place",
                ( Direction.Forward ) => "forward",
                _ => "Unknown direction",
            };
        }
    }
}
