using System;

namespace DocsAnalyzer
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string text = null;
            DocsDB docsDB = new();

            while ( text != "" )
            {
                Console.WriteLine( "Type $ if you want to add doc and anything else if you want to find doc" );
                text = Console.ReadLine();

                if ( text == "$" )
                {
                    Console.Write( "Enter some text pls: " );
                    text = Console.ReadLine();
                    Console.WriteLine();
                    docsDB.AddDoc( text );
                }
                else
                {
                    var res = docsDB.FindDocuments( text );
                    foreach ( var foundDocInfo in res )
                    {
                        Console.WriteLine( foundDocInfo );
                    }
                }


            }
        }
    }
}
