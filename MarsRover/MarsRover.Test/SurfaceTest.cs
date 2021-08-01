using Xunit;
using MarsRover.Interface;
using MarsRover.Implementation;

namespace MarsRover.Test
{
    public class SurfaceTest
    {
        /*
        [Fact]
        public void When_PositiveCoorinatesX_OutOfSurface_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(6, 2)));
        }

        [Fact]
        public void When_NegativeCoorinatesX_OutOfSurface_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(-1, 2)));
        }

        [Fact]
        public void When_PositiveCoorinatesY_OutOfSurface_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(2, 6)));
        }

        [Fact]
        public void When_NegativeCoorinatesY_OutOfSurface_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(2, -1)));
        }

        [Fact]
        public void When_CoorinatesXY_BelowLowSurfaceCoordinates_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(-1, -1)));
        }

        [Fact]
        public void When_CoorinatesXY_AboveLowSurfaceCoordinates_ReturnFalse()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(6, 6)));
        }*/

        [Theory]
        [InlineData(6, 2)]
        [InlineData(-1, 2)]
        [InlineData(2, 6)]
        [InlineData(2, -1)]
        [InlineData(-1, -1)]
        [InlineData(6, 6)]
        public void When_CoorinatesXY_OutOfSurfaceRange_ReturnFalse(int posX, int posY)
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.False(surface.IsValidCoordinateToPlace(new DTO.Coordinate(posX, posY)));
        }

        [Fact]
        public void When_CoorinatesXY_WithinSurfaceRange_ReturnTrue()
        {
            ISurface surface = new Plateau();
            surface.SetSurface(new DTO.Coordinate(0, 0), new DTO.Coordinate(5, 5));
            Assert.True(surface.IsValidCoordinateToPlace(new DTO.Coordinate(2, 3)));
        }
    }
}