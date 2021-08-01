using MarsRover.DTO;

namespace MarsRover.Interface
{
    public interface ISurface
    {
        public void SetSurface(Coordinate minCoordinate, Coordinate maxCoordinate);

        public bool IsValidCoordinateToPlace(Coordinate coordinate);
    }
}