using CarSimulator;
using Xunit;

namespace CarTests
{
    public class CarTests
    {
        [Fact]
        public void Car_CreateObjectUsingConstructor_CreatesCarWithCorrectState()
        {
            //arrange
            Car car = new();

            //act

            //assert
            Assert.True( car.Speed == 0, "Car object has been created with incorrect speed." );
            Assert.True( car.IsEngineRunning == false, "Car object has been created with running engine." );
            Assert.True( car.Gear == Gear.Neutral, "Car object has been created with incorrect gear." );
            Assert.True( car.Direction == Direction.OnPlace, "Car object has been created with incorrect direction." );
        }

        [Fact]
        public void Car_TurnEngineOnAfterCarHasBeenCreated_ReturnsTrueAndSetsEngineOn()
        {
            //arrange
            Car car = new();

            //act
            var result = car.TurnOnEngine();

            //assert
            Assert.True( result == true, "TurnOnEngine failed right after car object creation." );
            Assert.True( car.IsEngineRunning == true, "TurnOnEngine didnt set IsTurnedOn on true." );
            Assert.True( car.Speed == 0, "TurnOnEngine changed speed." );
            Assert.True( car.Gear == Gear.Neutral, "TurnOnEngine changed gear." );
            Assert.True( car.Direction == Direction.OnPlace, "TurnOnEngine changed direction." );
        }

        [Fact]
        public void Car_TurnEngineOffWhenItsAlreadyTurnedOff_ReturnsTrue()
        {
            //arrange
            Car car = new();

            //act
            var result = car.TurnOffEngine();

            //assert
            Assert.True( result == true, "TurnOffEngine failed when engine was turned off." );
            Assert.True( car.IsEngineRunning == false, "TurnOffEngine turned car on." );
            Assert.True( car.Direction == Direction.OnPlace, "TurnOffEngine changed direction." );
        }

        [Fact]
        public void Car_TurnEngineOffWhenCarIsMoving_ReturnsFalse()
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            car.SetGear( Gear.First );
            car.SetSpeed( 10 );
            var result = car.TurnOffEngine();

            //assert
            Assert.True( result == false, "TurnOffEngine succeeded when car was moving." );
            Assert.True( car.IsEngineRunning == true, "TurnOffEngine turned car off when it was moving." );
        }

        [Fact]
        public void Car_SetGearToFirstWithCorrectParams_ReturnsTrueAndSetsFirstGear()
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            var result = car.SetGear( Gear.First );

            //assert
            Assert.True( result == true, "Failed to set first gear." );
            Assert.True( car.Gear == Gear.First, $"SetGear switched to {car.Gear} while trying to set First gear" );
            Assert.True( car.Direction == Direction.OnPlace, "SetGear changed direction." );
        }

        [Fact]
        public void Car_SetNegativeSpeed_ReturnsFalse()
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            var result = car.SetSpeed( -10 );

            //assert
            Assert.True( result == false && car.Speed == 0, "Succeeded to set negative speed." );
        }

        [Fact]
        public void Car_SetSpeedWithNeutralGearSetOn_ReturnsFalse()
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            var result = car.SetSpeed( 10 );

            //assert
            Assert.True( result == false && car.Speed == 0, "Succeeded to set speed while gear was neutral." );
        }

        [Fact]
        public void Car_SetSpeedWhileEngineIsTurnedOff_ReturnsFalse()
        {
            //arrange
            Car car = new();

            //act
            var result = car.SetSpeed( 10 );

            //assert
            Assert.True( result == false && car.Speed == 0, "Succeeded to set speed while engine was turned off." );
        }

        [Theory]
        [InlineData( Gear.First )]
        [InlineData( Gear.Reverse )]
        public void Car_SetGearFromNeutralWithCorrectValue_ReturnsTrue( Gear gear )
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            var result = car.SetGear( gear );

            //assert
            Assert.True( result == true, $"SetGear returns false when trying to set {gear} from Neutral." );
            Assert.True( car.Gear == gear, $"Failed to set {gear} from Neutral" );
        }

        [Theory]
        [InlineData( Gear.Second )]
        [InlineData( Gear.Third )]
        [InlineData( Gear.Fourth )]
        [InlineData( Gear.Fifth )]
        public void Car_SetGearFromNeutralWithIncorrectValue_ReturnsFalse( Gear gear )
        {
            //arrange
            Car car = CarFactory.GetCarWithTurnedOnEngine();

            //act
            var result = car.SetGear( gear );

            //assert
            Assert.True( result == false, $"SetGear returns true when trying to set {gear} from Neutral." );
            Assert.True( car.Gear == Gear.Neutral, $"Succeeded to set {gear} from Neutral" );
        }

        [Fact]
        public void Car_SetGearToReverseWhileMovingForward_ReturnsFalse()
        {
            //arrange
            Car car = CarFactory.GetCarWithFirstGearAndTenSpeed();

            //act
            var result = car.SetGear( Gear.Reverse );

            //assert
            Assert.True( result == false, $"SetGear returns true when trying to set Reverse gear whlie moving." );
            Assert.False( car.Gear == Gear.Reverse, $"Succeeded to set Reverse while moving forward." );
        }

        [Fact]
        public void Car_SetGearToReverseWhileMovingBackwardsOnNeutral_ReturnsFalse()
        {
            //arrange
            Car car = CarFactory.GetMovingBackwardsCarWithTenSpeed();

            //act
            var result = car.SetGear( Gear.Reverse );

            //assert
            Assert.True( result == false, $"SetGear returns true when trying to set Reverse gear whlie moving backwards." );
            Assert.False( car.Gear == Gear.Reverse, $"Succeeded to set Reverse while moving backwards." );
        }
    }
}
