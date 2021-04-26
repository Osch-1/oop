using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bodies.Models;
using Xunit;

namespace BodiesTests
{
    public class CompoundTests
    {
        [Fact]
        public void Compound_Constructor_ProperlyInitializeFields()
        {
            //arrange && act
            Compound compound = new();

            //assert
            Assert.True( compound.GetDensity().AreEqual( 0 ), "Compound constructor modified provided density." );
            Assert.True( compound.GetMass().AreEqual( 0 ), "Compound constructor incorrectly inits mass." );
            Assert.True( compound.GetVolume().AreEqual( 0 ), "Compound constructor incorrectly inits volume." );
        }

        [Fact]
        public void Compound_AddChildBody_AddsChild()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound compound = new();
            Cylinder cylinder = new( 10, 10, 10 );
            Parallelepiped parallelepiped = new( 10, 10, 10, 10 );
            Sphere sphere = new( 10, 10 );

            //act
            containerCompound.AddChildBody( cone );
            containerCompound.AddChildBody( compound );
            containerCompound.AddChildBody( cylinder );
            containerCompound.AddChildBody( parallelepiped );
            containerCompound.AddChildBody( sphere );

            //assert
            Assert.True( containerCompound.HasBodyDirectly( cone ) );
            Assert.True( containerCompound.HasBodyDirectly( compound ) );
            Assert.True( containerCompound.HasBodyDirectly( cylinder ) );
            Assert.True( containerCompound.HasBodyDirectly( parallelepiped ) );
            Assert.True( containerCompound.HasBodyDirectly( sphere ) );
        }

        [Fact]
        public void Compound_AddChildBody_CantAddItselfDirectly()
        {
            //arrange
            Compound containerCompound = new();
            Compound compound = containerCompound;

            //act            
            var result = containerCompound.AddChildBody( compound );

            //assert            
            Assert.True( result == false );
            Assert.False( containerCompound.HasBodyDirectly( compound ) );
        }

        [Fact]
        public void Compound_AddChildBody_CantAddItselfIndirectly()
        {
            //arrange
            Compound containerCompound = new();
            Compound intermediateContainer = new();
            Compound intermediateContainer2 = new();
            Compound compound = containerCompound;

            //act            
            intermediateContainer.AddChildBody( compound );
            intermediateContainer2.AddChildBody( intermediateContainer );
            var result = containerCompound.AddChildBody( intermediateContainer2 );

            //assert            
            Assert.True( result == false );
            Assert.False( containerCompound.HasBodyDirectly( intermediateContainer2 ) );
        }

        [Fact]
        public void Compound_GetParams_ReturnCorrectValues()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound childCompound = new();
            Cylinder cylinder = new( 10, 10, 10 );
            Parallelepiped parallelepiped = new( 10, 10, 10, 10 );
            Sphere sphere = new( 10, 10 );

            //act
            containerCompound.AddChildBody( cone );
            containerCompound.AddChildBody( childCompound );
            containerCompound.AddChildBody( cylinder );
            containerCompound.AddChildBody( parallelepiped );
            containerCompound.AddChildBody( sphere );

            //assert            
            Assert.True( containerCompound.GetVolume().AreEqual( 8330.382858376184 ), "Compound body volume has been counted encorrectly." );
            Assert.True( containerCompound.GetMass().AreEqual( 83303.82858376185 ), "Compound body mass has been counted encorrectly." );
            Assert.True( containerCompound.GetDensity().AreEqual( 10 ), "Compound body density has been counted encorrectly." );
        }

        [Fact]
        public void Compound_GetParams_ReturnsCorrectValuesAfterChildCompoundHasBeenChanged()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound childCompound = new();
            Cylinder cylinder = new( 10, 10, 10 );

            //act
            containerCompound.AddChildBody( cone );
            containerCompound.AddChildBody( childCompound );
            childCompound.AddChildBody( cylinder );

            //assert            
            Assert.True( containerCompound.GetVolume().AreEqual( 4188.790204786391 ), "Compound body volume has been counted encorrectly." );
            Assert.True( containerCompound.GetMass().AreEqual( 41887.90204786391 ), "Compound body mass has been counted encorrectly." );
            Assert.True( containerCompound.GetDensity().AreEqual( 10 ), "Compound body density has been counted encorrectly." );
        }
    }
}
