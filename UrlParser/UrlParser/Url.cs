using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlParser
{
    /// <summary>
    /// Stores url
    /// Supports only http and https for now
    /// </summary>
    public class Url
    {
        private static readonly int _defaultHttpPort = 80;
        private static readonly int _defaultHttpsPort = 443;

        private Protocol _protocol;
        private string _domain;
        private string _uri;
        private int _port;

        public Url( string url )
        {
            if ( url == null )
                throw new ArgumentNullException( "Url can't be null" );
            if ( url == "" )
                throw new ArgumentException( "Url can't be empty" );

            Init( url );
        }

        public Url( string domain, string uri, Protocol protocol = Protocol.HTTP )
        {
            SetProtocol( protocol );
            SetDomain( domain );
            SetUri( uri );
            SetPortByProtocol( protocol );
        }

        public Url( string domain, string uri, int port, Protocol protocol = Protocol.HTTP )
        {
            SetProtocol( protocol );
            SetDomain( domain );
            SetUri( uri );
            SetPort( port );
        }

        public Protocol Protocol
        {
            get => _protocol;
        }

        public string Domain
        {
            get => _domain;
        }
        public string Uri
        {
            get => _uri;
        }
        public int Port
        {
            get => _port;
        }

        public override string ToString()
        {
            return $"{_protocol.ToString( "g" ).ToLower()}://{_domain}{_uri}";
        }

        private void Init( string url )
        {
            string protocol = ExtractProtocol( url );
            string port = ExtractPort( url );
            string domain = ExtractDomain( url );
            string uri = ExtractUri( url );

            _protocol = GetProtocolByString( protocol );
            if ( port == "" )
            {
                SetPortByProtocol( _protocol );
            }
            else
            {
                SetPort( port );
            }
            SetDomain( domain );
            SetUri( uri );
        }

        private string ExtractProtocol( string url )
        {
            Regex r = new( @"^(?<proto>\w+)://",
              RegexOptions.None, TimeSpan.FromMilliseconds( 150 ) );
            Match m = r.Match( url );

            return m.Groups[ "proto" ].Value;
        }

        private string ExtractPort( string url )
        {
            if ( url.Contains( @"://" ) )
                url = url.Split( new string[] { "://" }, 2, StringSplitOptions.None )[ 1 ];

            var splitRes = url.Split( ':' );
            if ( splitRes.Length == 2 )
                return splitRes[ ^1 ].Split( '/' )[ 0 ];
            return "";
        }

        private string ExtractDomain( string url )
        {
            if ( url.Contains( @"://" ) )
                url = url.Split( new string[] { "://" }, 2, StringSplitOptions.None )[ 1 ];

            return url.Split( '/' )[ 0 ].Split( ':' )[ 0 ];
        }

        private string ExtractUri( string url )
        {
            if ( url.Contains( @"://" ) )
                url = url.Split( new string[] { "://" }, 2, StringSplitOptions.None )[ 1 ];

            return string.Join( "/", url.Split( '/' )[ 1.. ] );
        }

        private void SetProtocol( Protocol protocol )
        {
            _protocol = protocol switch
            {
                Protocol.HTTP or Protocol.HTTPS => protocol,
                _ => throw new ArgumentException( $"Incorrect protocol has been provided: {protocol:g}" )
            };
        }

        private Protocol GetProtocolByString( string protocol )
        {
            return protocol.ToLower() switch
            {
                ( "http" or "" ) => Protocol.HTTP,
                ( "https" ) => Protocol.HTTPS,
                _ => throw new ArgumentException( $"Incorrect protocol has been provided: {protocol:g}" ),
            };
            ;
        }

        private void SetDomain( string domain )
        {
            //https://regexr.com/3au3g
            //по идее CPU -> 100%
            /*Regex domainRegex = new( @"(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z0-9][a-zA-Z0-9-]{0,61}[a-zA-Z0-9]" );
            if ( !domainRegex.IsMatch( domain ) )
                throw new ArgumentException( $"Incorrect domain: {domain}" );*/

            if ( domain == null )
                throw new ArgumentNullException( $"Domain can't be null" );

            if ( domain == "" )
                throw new ArgumentException( $"Domain can't be empty" );

            var domainParts = domain.Split( '.' ).ToList();
            foreach ( var domainPart in domainParts )
            {
                var parseResult = ParseDomainPart( domainPart );
                if ( !parseResult.IsSuccess )
                    throw new ArgumentException( $"Incorrect domain:\n{string.Join( '\n', parseResult.Errors )}" );
            }

            _domain = domain.ToLowerInvariant();
        }

        private ParseResult ParseDomainPart( string domainPart )
        {
            ParseResult result = new();
            if ( domainPart == null || domainPart == "" )
            {
                result.AddError( "Domain parts can't be empty" );
                return result;
            }

            return result;
        }

        private void SetUri( string uri )
        {
            if ( uri == null )
                throw new ArgumentNullException( $"Uri can't be null" );

            if ( uri == "" || uri == "/" )
            {
                _uri = "/";
                return;
            }

            var parseResult = uri[ 0 ] == '/' ? ParseUri( uri[ 1.. ] ) : ParseUri( uri );
            if ( !parseResult.IsSuccess )
                throw new ArgumentException( $"Incorrect uri:\n{string.Join( '\n', parseResult.Errors )}" );

            if ( uri[ 0 ] != '/' )
                uri = "/" + uri;

            _uri = uri;
        }

        private ParseResult ParseUri( string uri )
        {
            ParseResult result = new();
            var uriParts = uri.Split( '/' ).ToList();

            foreach ( var uriPart in uriParts )
            {
                if ( uriPart == null || uriPart == "" )
                    result.AddError( "Uri parts can't be empty" );
                break;
            }

            return result;
        }

        private void SetPortByProtocol( Protocol protocol )
        {
            _port = protocol switch
            {
                Protocol.HTTP => _defaultHttpPort,
                Protocol.HTTPS => _defaultHttpsPort,
                _ => throw new ArgumentException( "Incorrect protocol has been provided when trying to initialize port." )
            };
        }

        private void SetPort( string port )
        {
            var res = int.TryParse( port, out int intPort );
            if ( !res )
                throw new FormatException( $"Incorrect port format has been provided: {port}" );

            //не все порты > 0 доступны
            if ( intPort < 0 )
                throw new ArgumentException( $"Incorrect port value: {port}" );

            _port = intPort;
        }

        private void SetPort( int port )
        {
            //не все порты > 0 доступны
            if ( port < 0 )
                throw new ArgumentException( $"Incorrect port value: {port}" );

            _port = port;
        }

        private class ParseResult
        {
            private readonly List<string> _errors = new();
            public List<string> Errors
            {
                get
                {
                    return _errors;
                }
            }

            public void AddError( string errorMsg )
            {
                if ( errorMsg != null )
                    _errors.Add( errorMsg );
            }

            public bool IsSuccess => !_errors.Any();
        }
    }
}
