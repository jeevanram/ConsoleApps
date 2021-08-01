using MarsRover.Interface;

namespace MarsRover.Implementation
{
    public class MoveCommand : ICommand
    {
        public void Execute(IDevice device)
        {
            device.Move();
        }
    }
}