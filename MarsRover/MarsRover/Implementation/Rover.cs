using System;
using MarsRover.Interface;
using MarsRover.DTO;

namespace MarsRover.Implementation
{
    public class Rover : IDevice
    {
        public Coordinate Location { get; set; }
        public IDirection Direction { get; set; }
        public ISurface Surface { get; set; }

        public Rover(IDirection direction, ISurface surface)
        {
            this.Direction = direction;
            this.Surface = surface;
            this.Location = new Coordinate(0, 0);
        }

        public void RotateLeft()
        {
            this.Direction = this.Direction.RotateLeft();
        }

        public void RotateRight()
        {
            this.Direction = this.Direction.RotateRight();
        }

        public void Move()
        {
            this.Direction.Move(this);
        }

        public Coordinate GetLocation()
        {
            return new Coordinate(this.Location.PosX, this.Location.PosY);
        }

        public void SetLocation(Coordinate coordinate)
        {
            if (this.Surface.IsValidCoordinateToPlace(coordinate))
                this.Location = coordinate;
        }

        public void ActionToExecute(ICommand command)
        {
            command.Execute(this);
        }

        public string PrintLocation()
        {
            return $"{Location.PosX}-{Location.PosY}-{Direction.GetDirection()}";
        }
    }
}