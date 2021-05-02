using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies;
using Xunit;

namespace BodiesTests
{
    public class SphereTests
    {
        [Fact]
        public void Sphere_Constructor_ProperlyInitializeFields()
        {
            //arrange && act
            Sphere sphere = new( 100, 10 );

            //assert
            Assert.True( sphere.GetDensity() == 100, "Sphere constructor modified provided density." );
            Assert.True( sphere.GetRadius() == 10, "Sphere constructor modified provided radius." );
            Assert.True( sphere.GetMass().AreEqual( 314159.26535897935 ), "Sphere constructor incorrectly init mass." );
            Assert.True( sphere.GetVolume().AreEqual( 3141.5926535897934 ), "Sphere constructor incorrectly init volume." );
        }

        [Fact]
        public void Sphere_ToString_ReturnsCorrectValue()
        {
            //arrange
            Sphere sphere = new( 100, 10 );

            //act
            var stringifiedSphere = sphere.ToString();

            //assert
            Assert.Equal( "Volume: 3141,5926535897934, Mass: 314159,26535897935, Density: 100, Radius: 10", stringifiedSphere );
        }
    }
}
