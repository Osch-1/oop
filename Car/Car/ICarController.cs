using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public interface ICarController
    {
        void Info();
        bool EngineOn();
        bool EngineOff();
        bool SetGear( Gear gear );
        bool SetSpeed( int speed );
    }
}
