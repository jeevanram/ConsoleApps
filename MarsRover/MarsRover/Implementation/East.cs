using MarsRover.Interface;
using MarsRover.DTO;

namespace MarsRover.Implementation
{
    public class East : IDirection
    {
        public IDirection RotateLeft()
        {
            return new North();
        }

        public IDirection RotateRight()
        {
            return new South();
        }

        public void Move(IDevice device)
        {
            Coordinate coordinate = device.GetLocation();
            coordinate.PosX++;
            device.SetLocation(coordinate);
        }

        public string GetDirection()
        {
            return "East";
        }
    }
}