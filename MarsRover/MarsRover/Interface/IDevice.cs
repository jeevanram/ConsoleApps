using MarsRover.DTO;

namespace MarsRover.Interface
{
    public interface IDevice
    {
        public void RotateLeft();
        public void RotateRight();
        public void Move();
        public void SetLocation(Coordinate coordinate);
        public Coordinate GetLocation();
        public void ActionToExecute(ICommand command);
        public string PrintLocation();
    }
}