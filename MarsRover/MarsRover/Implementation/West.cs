using MarsRover.Interface;
using MarsRover.DTO;

namespace MarsRover.Implementation
{
    public class West : IDirection
    {
        public IDirection RotateLeft()
        {
            return new South();
        }

        public IDirection RotateRight()
        {
            return new North();
        }

        public void Move(IDevice device)
        {
            Coordinate coordinate = device.GetLocation();
            coordinate.PosX--;
            device.SetLocation(coordinate);
        }

        public string GetDirection()
        {
            return "West";
        }
    }
}