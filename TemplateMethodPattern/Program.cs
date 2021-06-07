
using System;

namespace TemplateMethidPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter the interview process to review");
                Console.WriteLine("1. IT Interview");
                Console.WriteLine("2. Automobile Interview");
                Console.WriteLine("3. Chef Interview");
                Console.WriteLine("Please choose 1/2/3 :");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    if (option < 1 || option > 3)
                    {
                        Console.WriteLine("Please enter a valid option !");
                    }
                    else
                    {
                        IInterviewProcess interviewProcess = GetInterviewProcess(option);
                        interviewProcess.Process();
                    }
                }
                Console.WriteLine("Do you want to continue ? (y/n)");
            } while (Console.ReadLine().ToUpper().Equals("Y"));
        }

        static IInterviewProcess GetInterviewProcess(int option)
        {
            switch(option)
            {
                case 1:
                    return new ITInterviewProcess();
                case 2:
                    return new AutomobileInterviewProcess();
                case 3:
                default:
                    return new ChefInterviewProcess();
            }
        }


    }
}
