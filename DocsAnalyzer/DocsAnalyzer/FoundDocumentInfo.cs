using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAnalyzer
{
    public class FoundDocumentInfo// : IComparable<FoundDocumentInfo>
    {
        private readonly int _id;
        private readonly int _relevance;

        public FoundDocumentInfo( int id, int relevance )
        {
            _id = id;
            _relevance = relevance;
        }

        public int Id => _id;

        public int Relevance => _relevance;

        public override string ToString()
        {
            return $"Document id: {Id}\nRelevance: {Relevance}";
        }

        /*public int CompareTo( FoundDocumentInfo other )
        {
            return Relevance.CompareTo( other.Relevance );
        }*/
    }
}
