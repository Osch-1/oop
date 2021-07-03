using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsAnalyzer
{
    public sealed class DocsDB
    {
        private readonly Dictionary<string, List<int>> _documentsInvertedIndex;
        private readonly List<DocumentInfo> _documents;
        private int _currId = 0;

        public DocsDB()
        {
            _documentsInvertedIndex = new();
            _documents = new();
        }

        public int AddDoc( string text )
        {
            if ( text == null )
                throw new ArgumentNullException( "AddDoc: text param can't be null" );

            if ( text == "" )
                throw new ArgumentException( "AddDoc: text param can't be empty" );

            _currId++;
            DocumentInfo document = new DocumentInfo( _currId, text );
            _documents.Add( document );
            try
            {
                AddDocumentInInvertedIndex( document );
            }
            catch ( OutOfMemoryException ex )
            {
                throw new OutOfMemoryException( "AddDoc: couldn't add document", ex );
            }

            return _currId;
        }

        //можно присваивать null, тогда можно id сопоставиьт с позиицей в списке и будет константное время удаления
        public void DeleteDoc( int id )
        {
            if ( id < 0 )
                throw new ArgumentException( "DeleteDoc: incorrect document id" );

            if ( id > GetDocsCount() )
                throw new ArgumentOutOfRangeException( "DeleteDoc: No such document" );

            for ( int i = 0; i < _documents.Count; i++ )
            {
                if ( _documents[ i ].Id == id )
                {
                    ClearInvertedIndexByDocumentInfo( _documents[ i ] );
                    _documents.RemoveAt( i );
                    break;
                }
            }
        }

        public int GetDocsCount()
        {
            return _documents.Count;
        }

        public List<FoundDocumentInfo> FindDocuments( string query )
        {
            var documentIdToRelevance = new Dictionary<int, int>();
            var result = new List<FoundDocumentInfo>();

            if ( IsNoReasonToSearch( query ) )
                return result;

            List<string> queryWords = query.Split( ' ' ).Where( w => w != " " ).Select( w => w.ToLower() ).Distinct().ToList();

            foreach ( string word in queryWords )
            {
                if ( !_documentsInvertedIndex.ContainsKey( word ) )
                    continue;

                var relevantDocsId = _documentsInvertedIndex[ word ];
                foreach ( int relevantDocumentId in relevantDocsId )
                {
                    if ( documentIdToRelevance.ContainsKey( relevantDocumentId ) )
                    {
                        documentIdToRelevance[ relevantDocumentId ]++;
                    }
                    else
                    {
                        documentIdToRelevance[ relevantDocumentId ] = 1;
                    }
                }
            }

            //доп обход по всем документам
            result = documentIdToRelevance.Select( kv => new FoundDocumentInfo( kv.Key, kv.Value ) ).ToList();

            return result.OrderByDescending( fd => fd.Relevance ).ToList();
        }

        private void AddDocumentInInvertedIndex( DocumentInfo document )
        {
            List<string> documentsWord = document.Text.Split( ' ' ).ToList();

            foreach ( string word in documentsWord )
            {
                string wordToLower = word.ToLower();
                if ( _documentsInvertedIndex.ContainsKey( wordToLower ) )
                {
                    _documentsInvertedIndex[ wordToLower ].Add( document.Id );
                }
                else
                {
                    try
                    {
                        _documentsInvertedIndex.Add( wordToLower, new List<int> { document.Id } );
                    }
                    catch ( OutOfMemoryException ex )
                    {
                        ClearInvertedIndexByDocumentInfo( document );
                        throw new OutOfMemoryException( "Couldn't allocate while trying to add document", ex );
                    }
                }
            }
        }

        private void ClearInvertedIndexByDocumentInfo( DocumentInfo document )
        {
            var documentWords = document.Text.Split( ' ' ).ToList();
            foreach ( var word in documentWords )
            {
                if ( _documentsInvertedIndex.ContainsKey( word ) )
                {
                    if ( _documentsInvertedIndex[ word ].Count == 1 && _documentsInvertedIndex[ word ][ 0 ] == document.Id )
                        _documentsInvertedIndex.Remove( word );
                    else
                        _documentsInvertedIndex[ word ].RemoveAll( id => id == document.Id );
                }
            }
        }

        private bool IsNoReasonToSearch( string query )
        {
            return query == null
              || query == ""
              || _documents.Count == 0;
        }
    }
}
