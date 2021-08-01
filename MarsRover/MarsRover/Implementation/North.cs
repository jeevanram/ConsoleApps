using MarsRover.Interface;
using MarsRover.DTO;

namespace MarsRover.Implementation
{
    public class North : IDirection
    {
        public IDirection RotateLeft()
        {
            return new West();
        }

        public IDirection RotateRight()
        {
            return new East();
        }

        public void Move(IDevice device)
        {
            Coordinate coordinate = device.GetLocation();
            coordinate.PosY++;
            device.SetLocation(coordinate);
        }

        public string GetDirection()
        {
            return "North";
        }
    }
}