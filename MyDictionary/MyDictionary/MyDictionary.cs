using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public sealed class WordDictionary
    {
        private static readonly string _defaultPath = "";
        private readonly string _path;
        private Dictionary<string, List<string>> _dictionary;

        public WordDictionary( string path )
        {
            _path = path;

            InitDictionaryFromFile( path );
        }

        public string GetTranslate( string word )
        {

        }

        private void InitDictionaryFromFile( string path )
        {

        }
    }
}
