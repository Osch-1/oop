using Bodies;
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
            containerCompound.AddChild( cone );
            containerCompound.AddChild( compound );
            containerCompound.AddChild( cylinder );
            containerCompound.AddChild( parallelepiped );
            containerCompound.AddChild( sphere );

            //assert
            Assert.True( containerCompound.Contains( cone ) );
            Assert.True( containerCompound.Contains( compound ) );
            Assert.True( containerCompound.Contains( cylinder ) );
            Assert.True( containerCompound.Contains( parallelepiped ) );
            Assert.True( containerCompound.Contains( sphere ) );
        }

        [Fact]
        public void Compound_AddChildBody_CantAddItselfDirectly()
        {
            //arrange
            Compound containerCompound = new();
            Compound compound = containerCompound;

            //act            
            var result = containerCompound.AddChild( compound );

            //assert            
            Assert.True( result == false );
            Assert.False( containerCompound.Contains( compound ) );
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
            intermediateContainer.AddChild( compound );
            intermediateContainer2.AddChild( intermediateContainer );
            var result = containerCompound.AddChild( intermediateContainer2 );

            //assert            
            Assert.True( result == false );
            Assert.False( containerCompound.Contains( intermediateContainer2 ) );
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
            containerCompound.AddChild( cone );
            containerCompound.AddChild( childCompound );
            containerCompound.AddChild( cylinder );
            containerCompound.AddChild( parallelepiped );
            containerCompound.AddChild( sphere );

            //assert            
            Assert.True( containerCompound.GetVolume().AreEqual( 8330.382858376184 ), "Compound body volume has been counted incorrectly." );
            Assert.True( containerCompound.GetMass().AreEqual( 83303.82858376185 ), "Compound body mass has been counted incorrectly." );
            Assert.True( containerCompound.GetDensity().AreEqual( 10 ), "Compound body density has been counted incorrectly." );
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
            containerCompound.AddChild( cone );
            containerCompound.AddChild( childCompound );
            childCompound.AddChild( cylinder );

            //assert            
            Assert.True( containerCompound.GetVolume().AreEqual( 4188.790204786391 ), "Compound body volume has been counted incorrectly." );
            Assert.True( containerCompound.GetMass().AreEqual( 41887.90204786391 ), "Compound body mass has been counted incorrectly." );
            Assert.True( containerCompound.GetDensity().AreEqual( 10 ), "Compound body density has been counted incorrectly." );
        }

        [Fact]
        public void Compound_AddChild_CantAddSameObjectTwice()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );

            //act
            containerCompound.AddChild( cone );
            var result = containerCompound.AddChild( cone );

            //assert
            Assert.True( result == false, "AddChild lets add same object multiple times." );
        }

        [Fact]
        public void Compound_AddChild_CantAddObjectThatAlreadyHasParent()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound anotherCompound = new();

            //act
            containerCompound.AddChild( cone );
            var result = anotherCompound.AddChild( cone );

            //assert
            Assert.True( result == false, "AddChild lets add object that already has parent." );
        }

        [Fact]
        public void Compound_ToString_ReturnsCorrectValue()
        {
            //arrange
            Compound containerCompound = new();
            Cone cone = new( 10, 10, 10 );
            Compound childCompound = new();
            Cylinder cylinder = new( 10, 10, 10 );
            Parallelepiped parallelepiped = new( 10, 10, 10, 10 );
            Sphere sphere = new( 10, 10 );

            //act
            containerCompound.AddChild( cone );
            containerCompound.AddChild( childCompound );
            containerCompound.AddChild( cylinder );
            containerCompound.AddChild( parallelepiped );
            containerCompound.AddChild( sphere );

            var result = containerCompound.ToString();

            //assert
            Assert.Equal( "Volume: 8330,382858376184, Mass: 83303,82858376185, Density: 10\n  Volume: 1047,1975511965977, Mass: 10471,975511965977, Density: 10, Base radius: 10, Height: 10\n  Volume: 0, Mass: 0, Density: 0\n\n  Volume: 3141,5926535897934, Mass: 31415,926535897932, Density: 10, Base radius: 10, Height: 10\n  Volume: 1000, Mass: 10000, Density: 10, Width: 10, Height: 10, Depth: 10\n  Volume: 3141,5926535897934, Mass: 31415,926535897932, Density: 10, Radius: 10\n", result );
        }
    }
}
