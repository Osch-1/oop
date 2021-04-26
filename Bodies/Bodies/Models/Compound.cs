using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Interfaces;

namespace Bodies.Models
{
    public class Compound : IBody
    {
        private List<IBody> _components = new();

        public Compound()
        {

        }

        public double GetVolume()
        {
            return _components.Any() ? _components.Sum( c => c.GetVolume() ) : 0;
        }

        public double GetMass()
        {
            return _components.Any() ? _components.Sum( c => c.GetMass() ) : 0;
        }

        public double GetDensity()
        {
            return _components.Any() ? GetMass() / GetVolume() : 0;
        }

        public bool AddChildBody( IBody child )
        {
            if ( IsEqualToOrContainsThis( child ) || _components.Contains( child ) )
                return false;

            _components.Add( child );
            return true;
        }

        public bool HasBodyDirectly( IBody body )
        {
            return _components.Contains( body );
        }

        public override string ToString()
        {
            string res = "";

            foreach ( var component in _components )
            {
                res += $"  {component}";
            }
            return $"{base.ToString()}\n{res}";
        }

        //изменить проверку на зацикливание
        private bool IsEqualToOrContainsThis( IBody body )
        {
            //is
            if ( !( body is Compound ) || body == null )
                return false;

            //ReferenceEquals проверяет равенство (тождество объектов), null=null
            if ( ReferenceEquals( body, this ) )
                return true;

            Compound compound = this;

            return false;
        }
    }
}
