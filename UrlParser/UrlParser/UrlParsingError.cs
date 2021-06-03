using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlParser
{
    public class UrlParsingError
    {
        private List<string> _errors = new();

        public List<string> Errors { get => _errors; set => _errors = value; }

        public void Add( string err )
        {
            _errors.Add( err );
        }

        public void AddRange( IList<string> errors )
        {
            _errors.AddRange( errors );
        }
    }
}
