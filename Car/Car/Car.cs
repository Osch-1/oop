using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class Car
    {
        private int _speed;
        private bool _isEngineRunning;
        private Gear _gear;
        private Direction _direction;

        public int Speed
        {
            get
            {
                return _speed;
            }
        }

        public bool IsEngineRunning
        {
            get
            {
                return _isEngineRunning;
            }
        }

        public Gear Gear
        {
            get
            {
                return _gear;
            }
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
        }

        public Car()
        {
            _speed = 0;
            _isEngineRunning = false;
            _gear = Gear.Neutral;
            _direction = Direction.OnPlace;
        }

        public bool TurnOnEngine()
        {
            _isEngineRunning = true;
            return true;
        }

        public bool TurnOffEngine()
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

        public bool SetGear( Gear gear )
        {
            return SwitchGear( gear );
        }

        public bool SetSpeed( int speed )
        {
            if ( !IsEngineRunning || speed is 0 )
            {
                return false;
            }

            if ( _gear is Gear.Reverse && speed >= 0 && speed <= 20 )
            {
                _speed = speed;
                ChangeDirection();
                return true;
            }
            if ( _gear is Gear.Neutral && speed <= _speed )
            {
                return false;
            }
            if ( _gear is Gear.First && speed >= 0 && speed <= 30 )
            {
                _speed = speed;
                ChangeDirection();
                return true;
            }
            if ( _gear is Gear.Second && speed >= 20 && speed <= 50 )
            {
                _speed = speed;
                return true;
            }
            if ( _gear is Gear.Third && speed >= 30 && speed <= 60 )
            {
                _speed = speed;
                return true;
            }
            if ( _gear is Gear.Fourth && speed >= 40 && speed <= 90 )
            {
                _speed = speed;
                return true;
            }
            if ( _gear is Gear.Fifth && speed >= 50 && speed <= 150 )
            {
                _speed = speed;
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

        private bool IsAbleToSetReverseGear()
        {
            return _speed is 0 && _isEngineRunning;
        }

        private bool IsAbleToSetFirstGear()
        {
            return ( ( _speed <= 30
                    && _speed >= 0
                    && _gear != Gear.Reverse ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                && _isEngineRunning;
        }

        private bool IsAbleToSetSecondGear()
        {
            return ( ( _speed <= 50
                    && _speed >= 20
                    && _gear != Gear.Reverse
                    && _direction != Direction.Backward ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetThirdGear()
        {
            return ( ( _speed <= 60
                    && _speed >= 30
                    && _gear != Gear.Reverse
                    && _direction != Direction.Backward ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetFourthGear()
        {
            return ( ( _speed <= 90
                    && _speed >= 40
                    && _gear != Gear.Reverse
                    && _direction != Direction.Backward ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }

        private bool IsAbleToSetFifthGear()
        {
            return ( ( _speed <= 150
                    && _speed >= 50
                    && _gear != Gear.Reverse
                    && _direction != Direction.Backward ) || ( _speed is 0 && _gear is Gear.Reverse ) )
                    && _isEngineRunning;
        }
    }
}
