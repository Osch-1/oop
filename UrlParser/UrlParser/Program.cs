using System;

namespace UrlParser
{
    class Program
    {
        static void Main( string[] args )
        {
            string input;
            while ( !string.IsNullOrEmpty( input = Console.ReadLine() ) )
            {
                try
                {
                    Url url = new( input );
                    Console.WriteLine( $"Protocol: {url.Protocol}\nDomain: {url.Domain}\nPort: {url.Port}\nUri: {url.Uri}\nRaw: {url}\n" );
                }
                catch ( Exception e )
                {
                    Console.WriteLine( e.Message );
                }
            }
        }
    }
}
