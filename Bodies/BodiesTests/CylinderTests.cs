using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Models;
using Xunit;

namespace BodiesTests
{
    public class CylinderTests
    {
        [Fact]
        public void Cylinder_Constructor_ProperlyInitializeFields()
        {
            //arrange && act
            Cylinder cylinder = new( 100, 10, 10 );

            //assert
            Assert.True( cylinder.GetDensity().AreEqual( 100 ), "Cylinder constructor modified provided density." );
            Assert.True( cylinder.GetMass().AreEqual( 314159.26535897935 ), "Cylinder constructor incorrectly inits mass." );
            Assert.True( cylinder.GetVolume().AreEqual( 3141.5926535897934 ), "Cylinder constructor incorrectly inits volume." );
            Assert.True( cylinder.GetHeight().AreEqual( 10 ), "Cylinder constructor incorrectly inits height." );
            Assert.True( cylinder.GetBaseRadius().AreEqual( 10 ), "Cylinder constructor incorrectly inits height." );
        }

        [Fact]
        public void Cylinder_ToString_ReturnsCorrectValue()
        {
            //arrange
            Cylinder cylinder = new( 100, 10, 10 );

            //act
            var stringifiedCylinder = cylinder.ToString();

            //assert
            Assert.Equal( "Volume: 3141,5926535897934, Mass: 314159,26535897935, Density: 100, Base radius: 10, Height: 10", stringifiedCylinder );
        }
    }
}
