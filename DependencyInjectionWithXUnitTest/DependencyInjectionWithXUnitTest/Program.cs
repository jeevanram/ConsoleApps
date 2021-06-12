using System;
using System.Collections.Generic;

namespace DependencyInjection_UnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"Enter the car model you wish to create :");
                Console.WriteLine($"1. BasicModel");
                Console.WriteLine($"2. SportsModel");
                Console.WriteLine($"3. ElectricModel");
                string option = Console.ReadLine();
                Console.WriteLine((new Program()).TestDrive(option));
                Console.WriteLine($"Do you want to continue(y/n) ?");
            } while (Console.ReadLine().ToUpper().Equals("Y"));
        }

        public string TestDrive(string carModel)
        {
            ICar car = GetCar(carModel);
            return car.TestDrive();
        }

        public ICar GetCar(string carModel)
        {
            IEngine engine;
            IBrakingSystem brakingSystem;
            List<IWheel> wheels;
            ICar car;

            switch(carModel)
            {
                default:
                case "BasicModel":
                    engine = new InlineEngine();
                    brakingSystem = new DiscBrakingSystem();
                    wheels = new List<IWheel>()
                    {
                        new SteelWheel("FrontLeftWheel"),
                        new SteelWheel("FrontRightWheel"),
                        new SteelWheel("RearLeftWheel"),
                        new SteelWheel("RearRightWheel")
                    };
                    car = new Car(engine, wheels, brakingSystem);
                    break;

                case "SportsModel":
                    engine = new VEngine();
                    brakingSystem = new DiscBrakingSystem();
                    wheels = new List<IWheel>()
                    {
                        new AlloyWheel("FrontLeftWheel"),
                        new AlloyWheel("FrontRightWheel"),
                        new AlloyWheel("RearLeftWheel"),
                        new AlloyWheel("RearRightWheel")
                    };
                    car = new Car(engine, wheels, brakingSystem);
                    break;

                case "ElectricModel":
                    engine = new ElectricEngine();
                    brakingSystem = new AntiLockBrakingSystem();
                    wheels = new List<IWheel>()
                    {
                        new AlloyWheel("FrontLeftWheel"),
                        new AlloyWheel("FrontRightWheel"),
                        new AlloyWheel("RearLeftWheel"),
                        new AlloyWheel("RearRightWheel")
                    };
                    car = new Car(engine, wheels, brakingSystem);
                    break;
            }

            return car;
        }
    }
}
