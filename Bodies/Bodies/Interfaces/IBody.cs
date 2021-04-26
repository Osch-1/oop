using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Models;

namespace Bodies.Interfaces
{
    //переработать иерархию, SolidBody
    public interface IBody
    {
        public double GetVolume();
        public double GetDensity();
        public double GetMass();
    }
}
