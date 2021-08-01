using MarsRover.Interface;

namespace MarsRover.Implementation
{
    public class LeftCommand : ICommand
    {
        public void Execute(IDevice device)
        {
            device.RotateLeft();
        }
    }
}