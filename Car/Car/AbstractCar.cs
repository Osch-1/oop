using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public abstract class AbstractCar
    {
        protected int _speed;
        protected bool _isEngineRunning;
        protected Gear _gear;
        protected Direction _direction;

        public AbstractCar()
        {
            _speed = 0;
            _isEngineRunning = false;
            _gear = Gear.Neutral;
            _direction = Direction.OnPlace;
        }

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

        public virtual bool TurnOnEngine()
        {
            return true;
        }

        public virtual bool TurnOffEngine()
        {
            return true;
        }

        public virtual bool SetGear( Gear gear )
        {
            return true;
        }

        public virtual bool SetSpeed( int speed )
        {
            return true;
        }
    }
}
