using Xunit;
using MarsRover.Interface;
using MarsRover.Implementation;
using Moq;

namespace MarsRover.Test
{
    public class CommandTest
    {
        [Fact]
        public void LeftCommand_WhenExecuted_InvokeRoverRotateLeft()
        {
            ICommand leftCommand = new LeftCommand();
            Mock<IDevice> device = new Mock<IDevice>();
            leftCommand.Execute(device.Object);

            device.Verify(dvc => dvc.RotateLeft(), Times.Once);
            device.Verify(dvc => dvc.RotateRight(), Times.Never);
            device.Verify(dvc => dvc.Move(), Times.Never);
        }

        [Fact]
        public void RightCommand_WhenExecuted_InvokeRoverRotateRight()
        {
            ICommand rightCommand = new RightCommand();
            Mock<IDevice> device = new Mock<IDevice>();
            rightCommand.Execute(device.Object);

            device.Verify(dvc => dvc.RotateLeft(), Times.Never);
            device.Verify(dvc => dvc.RotateRight(), Times.Once);
            device.Verify(dvc => dvc.Move(), Times.Never);
        }

        [Fact]
        public void MoveCommand_WhenExecuted_InvokeRoverMove()
        {
            ICommand moveCommand = new MoveCommand();
            Mock<IDevice> device = new Mock<IDevice>();
            moveCommand.Execute(device.Object);

            device.Verify(dvc => dvc.RotateLeft(), Times.Never);
            device.Verify(dvc => dvc.RotateRight(), Times.Never);
            device.Verify(dvc => dvc.Move(), Times.Once);
        }
    }
}