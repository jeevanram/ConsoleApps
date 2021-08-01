using Xunit;
using MarsRover.Interface;
using MarsRover.Implementation;
using Moq;

namespace MarsRover.Test
{
    public class UnitTest1
    {
        [Fact]
        public void When_East_OnRotateLeft_MoveTo_North()
        {
            IDirection direction = new East();
            direction = direction.RotateLeft();
            Assert.Equal("North", direction.GetDirection());
        }

        [Fact]
        public void When_East_OnRotateRight_MoveTo_South()
        {
            IDirection direction = new East();
            direction = direction.RotateRight();
            Assert.Equal("South", direction.GetDirection());
        }

        [Fact]
        public void When_West_OnRotateLeft_MoveTo_South()
        {
            IDirection direction = new West();
            direction = direction.RotateLeft();
            Assert.Equal("South", direction.GetDirection());
        }

        [Fact]
        public void When_West_OnRotateRight_MoveTo_North()
        {
            IDirection direction = new West();
            direction = direction.RotateRight();
            Assert.Equal("North", direction.GetDirection());
        }

        [Fact]
        public void When_North_OnRotateLeft_MoveTo_West()
        {
            IDirection direction = new North();
            direction = direction.RotateLeft();
            Assert.Equal("West", direction.GetDirection());
        }

        [Fact]
        public void When_North_OnRotateRight_MoveTo_East()
        {
            IDirection direction = new North();
            direction = direction.RotateRight();
            Assert.Equal("East", direction.GetDirection());
        }

        [Fact]
        public void When_South_OnRotateLeft_MoveTo_East()
        {
            IDirection direction = new South();
            direction = direction.RotateLeft();
            Assert.Equal("East", direction.GetDirection());
        }

        [Fact]
        public void When_South_OnRotateRight_MoveTo_West()
        {
            IDirection direction = new South();
            direction = direction.RotateRight();
            Assert.Equal("West", direction.GetDirection());
        }

        [Fact]
        public void When_South_OnMove_DecrementCoordinateY()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            IDirection direction = new South();
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<DTO.Coordinate>())).Returns(true);
            IDevice rover = new Rover(direction, surface.Object);
            rover.SetLocation(new DTO.Coordinate(1, 2));
            direction.Move(rover);

            Assert.Equal(1, rover.GetLocation().PosY);
        }

        [Fact]
        public void When_East_OnMove_IncrementCoordinateX()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            IDirection direction = new East();
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<DTO.Coordinate>())).Returns(true);
            IDevice rover = new Rover(direction, surface.Object);
            rover.SetLocation(new DTO.Coordinate(1, 1));
            direction.Move(rover);

            Assert.Equal(2, rover.GetLocation().PosX);
        }

        [Fact]
        public void When_West_OnMove_DecrementCoordinateX()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            IDirection direction = new West();
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<DTO.Coordinate>())).Returns(true);
            IDevice rover = new Rover(direction, surface.Object);
            rover.SetLocation(new DTO.Coordinate(2, 1));
            direction.Move(rover);

            Assert.Equal(1, rover.GetLocation().PosX);
        }

        [Fact]
        public void When_North_OnMove_IncrementCoordinateY()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            IDirection direction = new North();
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<DTO.Coordinate>())).Returns(true);
            IDevice rover = new Rover(direction, surface.Object);
            rover.SetLocation(new DTO.Coordinate(1, 1));
            direction.Move(rover);

            Assert.Equal(2, rover.GetLocation().PosY);
        }
    }
}
