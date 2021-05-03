using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public class Compound : InsertableBody
    {
        private readonly List<InsertableBody> _components = new();

        public Compound()
        {
        }

        public Compound( List<InsertableBody> bodies )
        {
            _components.AddRange( bodies );
        }

        public override double GetVolume()
        {
            return _components.Any() ? _components.Sum( c => c.GetVolume() ) : 0;
        }

        public override double GetMass()
        {
            return _components.Any() ? _components.Sum( c => c.GetMass() ) : 0;
        }

        public override double GetDensity()
        {
            if ( _components.Any() )
            {
                double volume = GetVolume();
                if ( volume != 0 )
                    return GetMass() / GetVolume();
            }

            return 0;
        }

        public bool AddChild( InsertableBody child )
        {
            if ( !IsAbleToAdd( child ) )
                return false;

            _components.Add( child );
            child.ParentBody = this;

            return true;
        }

        public bool Contains( InsertableBody body )
        {
            return _components.Contains( body );
        }

        public override string ToString()
        {
            string res = $"";

            foreach ( var component in _components )
            {
                res += $"  {component}\n";
            }

            return $"{base.ToString()}\n{res}";
        }

        private bool IsAbleToAdd( InsertableBody child )
        {
            if ( child == this
              || ( ( child is Compound ) && HasParent( child as Compound ) )
              || child.GetParent() != null )
                return false;

            return true;
        }
    }
}
