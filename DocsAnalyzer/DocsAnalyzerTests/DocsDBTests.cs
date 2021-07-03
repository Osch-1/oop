using DocsAnalyzer;
using NUnit.Framework;

namespace DocsAnalyzerTests
{
    public class DocsDBTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DocsDB_Constructor_NoParams_InitializesObject()
        {
            //Arrange 
            DocsDB docsDB;

            //Act
            docsDB = new();

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 0 );
        }

        [Test]
        public void DocsDB_FindDocuments_EmptyQueryAndNoDocs_ReturnsEmptyList()
        {
            //Arrange 
            DocsDB docsDB = new();

            //Act
            string emptyQuery = "";
            var foundDocs = docsDB.FindDocuments( emptyQuery );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 0 );
            Assert.IsTrue( foundDocs.Count == 0 );
        }

        [Test]
        public void DocsDB_AddDocument_NonEmptyText_ReturnsOneOnFirstInsertion()
        {
            //Arrange 
            DocsDB docsDB = new();
            string text = "Some kind of text with words";

            //Act            
            var addedDocId = docsDB.AddDoc( text );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 1 );
            Assert.AreEqual( 1, addedDocId );
        }

        [Test]
        public void DocsDB_AddDocument_MultipleTimes_ReturnsCorrectIds()
        {
            //Arrange 
            DocsDB docsDB = new();
            string text1 = "Some kind of text with words";
            string text2 = "Some kind of text with words";
            string text3 = "Some kind of text with words";

            //Act            
            var firstDocId = docsDB.AddDoc( text1 );
            var secondDocId = docsDB.AddDoc( text2 );
            var thirdDocId = docsDB.AddDoc( text3 );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 3 );
            Assert.AreEqual( 1, firstDocId );
            Assert.AreEqual( 2, secondDocId );
            Assert.AreEqual( 3, thirdDocId );
        }

        [Test]
        public void DocsDB_DeleteDocument_LastItemId_DeletesDocument()
        {
            //Arrange 
            DocsDB docsDB = new();
            string text1 = "Some kind of text with words";
            string text2 = "Some kind of text with words";
            string text3 = "Some kind of text with words";
            var firstDocId = docsDB.AddDoc( text1 );
            var secondDocId = docsDB.AddDoc( text2 );
            var thirdDocId = docsDB.AddDoc( text3 );

            //Act            
            docsDB.DeleteDoc( thirdDocId );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 2 );
            Assert.AreEqual( 1, firstDocId );
            Assert.AreEqual( 2, secondDocId );
        }

        [Test]
        public void DocsDB_DeleteDocument_MiddleItemId_DeletesDocument()
        {
            //Arrange 
            DocsDB docsDB = GetDbWithFiveDifferentElems();
            int docToBeDeletedId = 3;

            //Act            
            docsDB.DeleteDoc( docToBeDeletedId );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 4 );
        }

        [Test]
        public void DocsDB_AddDocument_AfterMiddleItemDelted_ReturnsCorrectId()
        {
            //Arrange 
            DocsDB docsDB = GetDbWithFiveDifferentElems();
            int docToBeDeletedId = 3;
            docsDB.DeleteDoc( docToBeDeletedId );
            string text = "Doc";

            //Act            
            int id = docsDB.AddDoc( text );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 5 );
            Assert.AreEqual( 6, id );
        }

        [Test]
        public void DocsDB_FindDocuments_EmptyDbNonEmptyQuery_ReturnsEmptyList()
        {
            //Arrange 
            DocsDB docsDB = new();

            //Act            
            var res = docsDB.FindDocuments( "Some query" );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 0 );
            Assert.IsTrue( res.Count == 0 );
        }

        [Test]
        public void DocsDB_FindDocuments_EmptyQueryNonEmptyDb_ReturnsEmptyList()
        {
            //Arrange 
            DocsDB docsDB = GetDbWithFiveDifferentElems();

            //Act            
            var res = docsDB.FindDocuments( "" );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 5 );
            Assert.IsTrue( res.Count == 0 );
        }

        [Test]
        public void DocsDB_FindDocuments_SubStringsOfWords_ReturnsEmptyList()
        {
            //Arrange 
            DocsDB docsDB = GetDbWithFiveDifferentElems();

            //Act            
            var res = docsDB.FindDocuments( "Som som kin o" );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 5 );
            Assert.IsTrue( res.Count == 0 );
        }

        [Test]
        public void DocsDB_FindDocuments_CorrectQuery_ReturnsCorrectFilesInfo()
        {
            //Arrange 
            DocsDB docsDB = GetDbForCommonRelevanceTest();

            //Act            
            var res = docsDB.FindDocuments( "Some kind of text with words" );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 5 );
            Assert.IsTrue( res.Count == 5 );

            Assert.IsTrue( res[ 0 ].Id == 1 );
            Assert.IsTrue( res[ 0 ].Relevance == 6 );

            Assert.IsTrue( res[ 1 ].Id == 2 );
            Assert.IsTrue( res[ 1 ].Relevance == 5 );

            Assert.IsTrue( res[ 2 ].Id == 3 );
            Assert.IsTrue( res[ 2 ].Relevance == 4 );

            Assert.IsTrue( res[ 3 ].Id == 4 );
            Assert.IsTrue( res[ 3 ].Relevance == 3 );

            Assert.IsTrue( res[ 4 ].Id == 5 );
            Assert.IsTrue( res[ 4 ].Relevance == 2 );
        }

        [Test]
        public void DocsDB_FindDocuments_CorrectQueryInDifferentOrderAndCase_ReturnsCorrectFilesInfo()
        {
            //Arrange 
            DocsDB docsDB = GetDbWithFiveDifferentElems();

            //Act            
            var res = docsDB.FindDocuments( "sOmE London kInD peOplE miGht I no it Inoccent people might be harmed" );

            //Assert
            Assert.IsTrue( docsDB.GetDocsCount() == 5 );
            Assert.IsTrue( res.Count == 5 );

            Assert.IsTrue( res[ 0 ].Id == 2 );
            Assert.IsTrue( res[ 0 ].Relevance == 6 );

            Assert.IsTrue( res[ 1 ].Id == 1 );
            Assert.IsTrue( res[ 1 ].Relevance == 4 );

            Assert.IsTrue( res[ 2 ].Id == 3 );
            Assert.IsTrue( res[ 2 ].Relevance == 2 );

            Assert.IsTrue( res[ 3 ].Id == 4 );
            Assert.IsTrue( res[ 3 ].Relevance == 1 );

            Assert.IsTrue( res[ 4 ].Id == 5 );
            Assert.IsTrue( res[ 4 ].Relevance == 1 );
        }

        private DocsDB GetDbWithFiveDifferentElems()
        {
            DocsDB docsDB = new();
            string text1 = "Some kind of text with words IT I";
            string text2 = "Some Inoccent people might be harmed";
            string text3 = "I have never been to London";
            string text4 = "And no, I can never beat you";
            string text5 = "Can it be, the night occured enough for";

            docsDB.AddDoc( text1 );
            docsDB.AddDoc( text2 );
            docsDB.AddDoc( text3 );
            docsDB.AddDoc( text4 );
            docsDB.AddDoc( text5 );

            return docsDB;
        }

        private DocsDB GetDbForCommonRelevanceTest()
        {
            DocsDB docsDB = new();
            string text1 = "Some kind of text with words";
            string text2 = "Some kind of text with";
            string text3 = "Some kind of text";
            string text4 = "Some kind of";
            string text5 = "Some kind";

            docsDB.AddDoc( text1 );
            docsDB.AddDoc( text2 );
            docsDB.AddDoc( text3 );
            docsDB.AddDoc( text4 );
            docsDB.AddDoc( text5 );

            return docsDB;
        }
    }
}