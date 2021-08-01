using MarsRover.Interface;
using MarsRover.Implementation;
using MarsRover.DTO;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            ISurface plateau = new Plateau();
            plateau.SetSurface(new Coordinate(0, 0), new Coordinate(5, 5));

            IDevice rover = new Rover(new North(), plateau);
            rover.SetLocation(new Coordinate(1, 2));

            rover.ActionToExecute(new LeftCommand());
            rover.ActionToExecute(new MoveCommand());
            rover.ActionToExecute(new LeftCommand());
            rover.ActionToExecute(new MoveCommand());
            rover.ActionToExecute(new LeftCommand());
            rover.ActionToExecute(new MoveCommand());
            rover.ActionToExecute(new LeftCommand());
            rover.ActionToExecute(new MoveCommand());
            rover.ActionToExecute(new MoveCommand());

            Console.WriteLine(rover.PrintLocation());

        }
    }
}
