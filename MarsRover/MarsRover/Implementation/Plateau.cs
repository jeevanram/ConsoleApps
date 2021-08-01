using System;
using MarsRover.Interface;
using MarsRover.DTO;

namespace MarsRover.Implementation
{
    public class Plateau : ISurface
    {
        public Coordinate MinCoordinate { get; set; }
        public Coordinate MaxCoordinate { get; set; }

        public void SetSurface(Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            this.MinCoordinate = minCoordinate;
            this.MaxCoordinate = maxCoordinate;
        }

        public bool IsValidCoordinateToPlace(Coordinate coordinate)
        {
            return (coordinate.PosX >= MinCoordinate.PosX && coordinate.PosX <= MaxCoordinate.PosX) &&
            (coordinate.PosY >= MinCoordinate.PosY && coordinate.PosY <= MaxCoordinate.PosY);
        }
    }
}