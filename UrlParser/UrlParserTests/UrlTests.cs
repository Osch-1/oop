using System;
using UrlParser;
using Xunit;

namespace UrlParserTests
{
    public class UrlTests
    {
        [Fact]
        public void Url_Constructor_CorrectParams_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Protocol protocol = Protocol.HTTPS;
            string domain = "drive.google.com";
            string uri = "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url;

            //Act
            url = new( domain, uri, protocol );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_Constructor_CorrectParams_CorrectlyInitializeObjectIfuriDoesntStartWithSlash()
        {
            //Arrange
            string urlStr = "https://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Protocol protocol = Protocol.HTTPS;
            string domain = "drive.google.com";
            string uri = "folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url;

            //Act
            url = new( domain, uri, protocol );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_Constructor_NullDomain_ThrowsNullArgExpection()
        {
            //Arrange            
            Protocol protocol = Protocol.HTTPS;
            string domain = null;
            string uri = "folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url = null;

            //Act
            Action action = () => { url = new( domain, uri, protocol ); };

            //Assert
            Assert.Throws<ArgumentNullException>( action );
        }

        [Fact]
        public void Url_Constructor_EmptyDomain_ThrowsArgExpection()
        {
            //Arrange            
            Protocol protocol = Protocol.HTTPS;
            string domain = "";
            string uri = "folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url = null;

            //Act
            Action action = () => { url = new( domain, uri, protocol ); };

            //Assert
            Assert.Throws<ArgumentException>( action );
        }

        [Fact]
        public void Url_Constructor_NullUri_ThrowsNullArgExpection()
        {
            //Arrange            
            Protocol protocol = Protocol.HTTPS;
            string domain = "domain";
            string uri = null;
            Url url = null;

            //Act
            Action action = () => { url = new( domain, uri, protocol ); };

            //Assert
            Assert.Throws<ArgumentNullException>( action );
        }

        [Fact]
        public void Url_Constructor_EmptyUri_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com/";
            Protocol protocol = Protocol.HTTPS;
            string domain = "drive.google.com";
            string uri = "";
            Url url;

            //Act
            url = new( domain, uri, protocol );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_Constructor_UriIsSlashOnly_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "http://drive.google.com/";
            Protocol protocol = Protocol.HTTP;
            string domain = "drive.google.com";
            string uri = "/";
            Url url;

            //Act
            url = new( domain, uri, protocol );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 80, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_ConstructorWithPort_CorrectParams_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Protocol protocol = Protocol.HTTPS;
            string domain = "drive.google.com";
            string uri = "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            int port = 8080;
            Url url;

            //Act
            url = new( domain, uri, port, protocol );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 8080, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_CorrectParams_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( urlStr, url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_NoProtocol_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 80, url.Port );
            Assert.Equal( "http://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_CorrectUrlWithPort_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com:222/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.Uri );
            Assert.Equal( 222, url.Port );
            Assert.Equal( "https://drive.google.com/folderview?id=0B8c4dq91MwITUk1RU1ZwWjFsWUk&usp=sharing", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_CorrectUrlWithoutDocument_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( "https://drive.google.com/", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_CorrectUrlWithSlashDocument_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "https://drive.google.com/";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTPS, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( "https://drive.google.com/", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_BrowserUrlString_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "drive.google.com";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 80, url.Port );
            Assert.Equal( "http://drive.google.com/", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_BrowserUrlStringWithPort_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "drive.google.com:8080";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 8080, url.Port );
            Assert.Equal( "http://drive.google.com/", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_BrowserUrlStringWithPortAndSlash_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "drive.google.com:8080/";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "drive.google.com", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 8080, url.Port );
            Assert.Equal( "http://drive.google.com/", url.ToString() );
        }

        [Fact]
        public void Url_ConstructorFromUrl_EmptyString_ThrowsArgException()
        {
            //Arrange
            string urlStr = "";
            Url url;

            //Act
            Action action = () => url = new( urlStr );

            //Assert
            Assert.Throws<ArgumentException>( action );
        }

        [Fact]
        public void Url_ConstructorFromUrl_NullValue_ThrowsArgNullException()
        {
            //Arrange
            string urlStr = null;
            Url url;

            //Act
            Action action = () => url = new( urlStr );

            //Assert
            Assert.Throws<ArgumentNullException>( action );
        }

        [Fact]
        public void Url_ConstructorFromUrl_LocalhostFormat_CorrectlyInitializeObject()
        {
            //Arrange
            string urlStr = "localhost:443";
            Url url;

            //Act
            url = new( urlStr );

            //Assert
            Assert.Equal( Protocol.HTTP, url.Protocol );
            Assert.Equal( "localhost", url.Domain );
            Assert.Equal( "/", url.Uri );
            Assert.Equal( 443, url.Port );
            Assert.Equal( "http://localhost/", url.ToString() );
        }
    }
}
