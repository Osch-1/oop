using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator;
using Xunit;

namespace CarSimulatorTests
{
    class MockCar : AbstractCar
    {
        public MockCar()
            : base()
        { }

        public override bool TurnOnEngine()
        {
            _isEngineRunning = true;
            return true;
        }

        public override bool TurnOffEngine()
        {
            _isEngineRunning = false;
            return true;
        }

        public override bool SetGear( Gear gear )
        {
            _gear = gear;
            return true;
        }

        public override bool SetSpeed( int speed )
        {
            _speed = speed;
            return true;
        }
    }

    public class CarControllerTests
    {
        [Fact]
        public void CarController_EngineOn_CallsCarsTurnOnEngineMethod()
        {
            //arrange
            AbstractCar car = new MockCar();
            CarController carController = new( car );

            //act
            var result = carController.EngineOn();

            //assert

            Assert.True( result == true, "EngineOn failed to call cars engine on." );
            Assert.True( car.IsEngineRunning == true, "EngineOn failed to call cars engine on." );
        }

        [Fact]
        public void CarController_EngineOff_CallsCarsTurnOffEngineMethod()
        {
            //arrange
            AbstractCar car = new MockCar();
            CarController carController = new( car );

            //act
            var result = carController.EngineOff();

            //assert

            Assert.True( result == true, "EngineOff failed to call cars engine off." );
            Assert.True( car.IsEngineRunning == false, "EngineOff failed to call cars engine off." );
        }

        [Fact]
        public void CarController_SetGear_CallsCarsSetGearMethod()
        {
            //arrange
            AbstractCar car = new MockCar();
            CarController carController = new( car );

            //act
            var result = carController.SetGear( Gear.First );

            //assert

            Assert.True( result == true, "SetGear failed to call cars set gear method." );
            Assert.True( car.Gear == Gear.First, "SetGear failed to set cars gear." );
        }

        [Fact]
        public void CarController_SetSpeed_CallsCarsTurnOffEngineM1ethod()
        {
            //arrange
            AbstractCar car = new MockCar();
            CarController carController = new( car );

            //act
            var result = carController.SetSpeed( 10 );

            //assert

            Assert.True( result == true, "SetSpeed failed to call cars set speed." );
            Assert.True( car.Speed == 10, "SetSpeed failed to set cars speed." );
        }
    }
}
