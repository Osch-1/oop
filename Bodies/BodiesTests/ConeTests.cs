using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Models;
using Xunit;

namespace BodiesTests
{
    public class ConeTests
    {
        [Fact]
        public void Cone_Constructor_ProperlyInitializeFields()
        {
            //arrange && act
            Cone cone = new( 100, 10, 10 );

            //assert
            Assert.True( cone.GetDensity().AreEqual( 100 ), "Cone constructor modified provided density." );
            Assert.True( cone.GetMass().AreEqual( 104719.75511965978 ), "Cone constructor incorrectly inits mass." );
            Assert.True( cone.GetVolume().AreEqual( 1047.1975511965977 ), "Cone constructor incorrectly inits volume." );
            Assert.True( cone.GetHeight().AreEqual( 10 ), "Cone constructor incorrectly inits height." );
            Assert.True( cone.GetBaseRadius().AreEqual( 10 ), "Cone constructor incorrectly inits height." );
        }

        [Fact]
        public void Cone_ToString_ReturnsCorrectValue()
        {
            //arrange
            Cone cylinder = new( 100, 10, 10 );

            //act
            var stringifiedCylinder = cylinder.ToString();

            //assert
            Assert.Equal( "Volume: 1047,1975511965977, Mass: 104719,75511965978, Density: 100, Base radius: 10, Height: 10", stringifiedCylinder );
        }
    }
}
