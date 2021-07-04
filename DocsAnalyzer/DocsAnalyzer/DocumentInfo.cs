using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAnalyzer
{
    public class DocumentInfo
    {
        private readonly int _id;
        private readonly string _text;

        public DocumentInfo( int id, string text )
        {
            if ( id < 0 )
                throw new ArgumentException();

            _id = id;
            _text = text;
        }

        public int Id => _id;

        public string Text => _text;
    }
}
