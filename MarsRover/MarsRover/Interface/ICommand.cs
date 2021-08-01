namespace MarsRover.Interface
{
    public interface ICommand
    {
        public void Execute(IDevice device);
    }
}
