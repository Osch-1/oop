using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSimulator;

namespace CarSimulator
{
    public class Car : AbstractCar
    {
        private readonly int _maxReverseSpeed = 20;
        private readonly int _minReverseSpeed = 0;
        private readonly int _maxFirstSpeed = 30;
        private readonly int _minFirstSpeed = 0;
        private readonly int _maxSecondSpeed = 50;
        private readonly int _minSecondSpeed = 20;
        private readonly int _maxThirdSpeed = 60;
        private readonly int _minThirdSpeed = 30;
        private readonly int _maxFourthSpeed = 90;
        private readonly int _minFourthSpeed = 40;
        private readonly int _maxFifthSpeed = 150;
        private readonly int _minFifthSpeed = 50;

        public Car()
            : base()
        { }

        public override bool TurnOnEngine()
        {
            _isEngineRunning = true;
            return true;
        }

        public override bool TurnOffEngine()
        {
            if ( !_isEngineRunning )
            {
                return true;
            }

            if ( IsAbleToTurnOffEngine() )
            {
                _isEngineRunning = false;
                return true;
            }

            return false;
        }

        public override bool SetGear( Gear gear )
        {
            return SwitchGear( gear );
        }

        public override bool SetSpeed( int speed )
        {
            if ( !IsEngineRunning || speed is 0 )
            {
                return false;
            }

            if ( IsAbleToSetSpeed( speed ) )
            {
                _speed = speed;
                ChangeDirection();
                return true;
            }

            return false;
        }

        private bool IsAbleToTurnOffEngine()
        {
            return _gear is Gear.Neutral
                && _direction is Direction.OnPlace
                && _speed is 0
                && _isEngineRunning;
        }

        private void ChangeDirection()
        {
            if ( _speed is 0 )
            {
                _direction = Direction.OnPlace;
            }

            if ( _speed > 0 && _gear is Gear.Reverse )
            {
                _direction = Direction.Backward;
            }

            if ( _speed > 0 && _gear != Gear.Reverse )
            {
                _direction = Direction.Forward;
            }
        }

        private bool SwitchGear( Gear gear )
        {
            switch ( gear )
            {
                case Gear.Reverse:
                    {
                        return SetReverseGear();
                    }
                case Gear.Neutral:
                    {
                        return SetNeutralGear();
                    }
                case Gear.First:
                    {
                        return SetFirstGear();
                    }
                case Gear.Second:
                    {
                        return SetSecondGear();
                    }
                case Gear.Third:
                    {
                        return SetThirdGear();
                    }
                case Gear.Fourth:
                    {
                        return SetFourthGear();
                    }
                case Gear.Fifth:
                    {
                        return SetFifthGear();
                    }
            }

            return false;
        }

        private bool SetReverseGear()
        {
            if ( IsAbleToSetReverseGear() )
            {
                _gear = Gear.Reverse;
                return true;
            }

            return false;
        }

        private bool SetNeutralGear()
        {
            _gear = Gear.Neutral;

            return true;
        }

        private bool SetFirstGear()
        {
            if ( IsAbleToSetFirstGear() )
            {
                _gear = Gear.First;
                return true;
            }

            return false;
        }

        private bool SetSecondGear()
        {
            if ( IsAbleToSetSecondGear() )
            {
                _gear = Gear.Second;
                return true;

            }

            return false;
        }

        private bool SetThirdGear()
        {
            if ( IsAbleToSetThirdGear() )
            {
                _gear = Gear.Third;
                return true;

            }
            return false;
        }

        private bool SetFourthGear()
        {
            if ( IsAbleToSetFourthGear() )
            {
                _gear = Gear.Fourth;
                return true;
            }

            return false;
        }

        private bool SetFifthGear()
        {
            if ( IsAbleToSetFifthGear() )
            {
                _gear = Gear.Fifth;
                return true;

            }

            return false;
        }

        private bool IsAbleToSetSpeed( int speed )
        {
            return _gear switch
            {
                Gear.Reverse => ( speed >= _minReverseSpeed && speed <= _maxReverseSpeed ),
                Gear.Neutral => ( speed >= 0 && speed < _speed ),
                Gear.First => ( speed >= _minFirstSpeed && speed <= _maxFirstSpeed ),
                Gear.Second => ( speed >= _minSecondSpeed && speed <= _maxSecondSpeed ),
                Gear.Third => ( speed >= _minThirdSpeed && speed <= _maxThirdSpeed ),
                Gear.Fourth => ( speed >= _minFourthSpeed && speed <= _maxFourthSpeed ),
                Gear.Fifth => ( speed >= _minFifthSpeed && speed <= _maxFifthSpeed ),
                _ => throw new Exception( "Trying to set speed with incorrect gear state." )
            };
        }

        private bool IsAbleToSetReverseGear()
        {
            return _speed is 0 && _isEngineRunning;
        }

        private bool IsAbleToSetFirstGear()
        {
            return ( ( _speed <= _maxFirstSpeed
                    && _speed >= _minFirstSpeed
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                && _isEngineRunning;
        }

        private bool IsAbleToSetSecondGear()
        {
            return ( ( _speed <= _maxSecondSpeed
                    && _speed >= _minSecondSpeed
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetThirdGear()
        {
            return ( ( _speed <= _maxThirdSpeed
                    && _speed >= _minThirdSpeed
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetFourthGear()
        {
            return ( ( _speed <= _maxFourthSpeed
                    && _speed >= _minFourthSpeed
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetFifthGear()
        {
            return ( ( _speed <= _maxFifthSpeed
                    && _speed >= _minFifthSpeed
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }
    }
}
