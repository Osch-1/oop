using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    public abstract class InsertableBody : Body
    {
        private Compound _parentBody;

        public Compound ParentBody
        {
            set
            {
                if ( value.Contains( this ) )
                    _parentBody = value;
            }
        }

        public Compound GetParent()
        {
            return _parentBody;
        }

        public bool HasParent( Compound body )
        {
            Compound parentBody = GetParent();

            while ( parentBody != null )
            {
                if ( ReferenceEquals( parentBody, body ) )
                {
                    return true;
                }

                parentBody = parentBody.GetParent();
            }

            return false;
        }
    }
}
