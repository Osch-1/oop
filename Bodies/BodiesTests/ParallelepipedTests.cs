using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies;
using Xunit;

namespace BodiesTests
{
    public class ParallelepipedTests
    {
        [Fact]
        public void Parallelepiped_Constructor_ProperlyInitializeFields()
        {
            //arrange && act
            InsertableBody parallelepiped = new Parallelepiped( 100, 10, 10, 10 );

            //assert
            Assert.True( parallelepiped.GetDensity().AreEqual( 100 ), "Parallelepiped constructor modified provided density." );
            Assert.True( parallelepiped.GetMass().AreEqual( 100000 ), "Parallelepiped constructor incorrectly inits mass." );
            Assert.True( parallelepiped.GetVolume().AreEqual( 1000 ), "Parallelepiped constructor incorrectly inits volume." );
            /*Assert.True( parallelepiped.GetWidth().AreEqual( 10 ), "Parallelepiped constructor incorrectly inits width." );
            Assert.True( parallelepiped.GetHeight().AreEqual( 10 ), "Parallelepiped constructor incorrectly inits height." );
            Assert.True( parallelepiped.GetDepth().AreEqual( 10 ), "Parallelepiped constructor incorrectly inits depth." );*/
        }

        [Fact]
        public void Parallelepiped_ToString_ReturnsCorrectValue()
        {
            //arrange
            Parallelepiped parallelepiped = new( 100, 10, 10, 10 );

            //act
            var stringifiedParallelepiped = parallelepiped.ToString();

            //assert
            Assert.Equal( "Volume: 1000, Mass: 100000, Density: 100, Width: 10, Height: 10, Depth: 10", stringifiedParallelepiped );
        }
    }
}
