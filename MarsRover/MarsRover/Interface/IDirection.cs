namespace MarsRover.Interface
{
    public interface IDirection
    {
        public IDirection RotateLeft();

        public IDirection RotateRight();

        public void Move(IDevice device);

        public string GetDirection();
    }
}