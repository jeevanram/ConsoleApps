using MarsRover.Interface;

namespace MarsRover.Implementation
{
    public class RightCommand : ICommand
    {
        public void Execute(IDevice device)
        {
            device.RotateRight();
        }
    }
}