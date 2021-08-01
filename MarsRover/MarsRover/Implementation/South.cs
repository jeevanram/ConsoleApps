using MarsRover.DTO;
using MarsRover.Interface;

namespace MarsRover.Implementation
{
    public class South : IDirection
    {
        public IDirection RotateLeft()
        {
            return new East();
        }

        public IDirection RotateRight()
        {
            return new West();
        }

        public void Move(IDevice device)
        {
            Coordinate coordinate = device.GetLocation();
            coordinate.PosY--;
            device.SetLocation(coordinate);
        }

        public string GetDirection()
        {
            return "South";
        }
    }
}