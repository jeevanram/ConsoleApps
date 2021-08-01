using Xunit;
using Moq;
using MarsRover.Interface;
using MarsRover.Implementation;
using MarsRover.DTO;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Fact]
        public void On_Rover_RotateLeft_Invoke_Direction_RotateLeft()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            Mock<IDirection> direction = new Mock<IDirection>();
            IDevice rover = new Rover(direction.Object, surface.Object);
            rover.RotateLeft();
            direction.Verify(dir => dir.RotateLeft(), Times.Once);
        }

        [Fact]
        public void On_Rover_RotateRight_Invoke_Direction_RotateRight()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            Mock<IDirection> direction = new Mock<IDirection>();
            IDevice rover = new Rover(direction.Object, surface.Object);
            rover.RotateRight();
            direction.Verify(dir => dir.RotateRight(), Times.Once);
        }

        [Fact]
        public void On_Rover_Move_Invoke_Direction_Move()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            Mock<IDirection> direction = new Mock<IDirection>();
            IDevice rover = new Rover(direction.Object, surface.Object);
            rover.Move();
            direction.Verify(dir => dir.Move(rover), Times.Once);
        }

        [Fact]
        public void On_Rover_WhenOutOfSurfaceCoordinateSent_DoNotUpdateLocation()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            Mock<IDirection> direction = new Mock<IDirection>();
            IDevice rover = new Rover(direction.Object, surface.Object);
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<Coordinate>())).Returns(false);
            rover.SetLocation(new Coordinate(2, 2));
            Assert.NotEqual(2, rover.GetLocation().PosX);
            Assert.NotEqual(2, rover.GetLocation().PosY);
        }
        [Fact]
        public void On_Rover_WhenWithinSurfaceCoordinateSent_UpdateLocation()
        {
            Mock<ISurface> surface = new Mock<ISurface>();
            Mock<IDirection> direction = new Mock<IDirection>();
            IDevice rover = new Rover(direction.Object, surface.Object);
            surface.Setup(sur => sur.IsValidCoordinateToPlace(It.IsAny<Coordinate>())).Returns(true);
            rover.SetLocation(new Coordinate(2, 2));
            Assert.Equal(2, rover.GetLocation().PosX);
            Assert.Equal(2, rover.GetLocation().PosY);
        }
    }
}