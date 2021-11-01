using GiftExchangeProblem.Interface;
using System;

namespace GiftExchangeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputUtility cSVUtility = new CSVUtility();
            INotificationService notificationService = new ConsoleNotification();
            MatcherGenerator matcherGenerator = new MatcherGenerator(notificationService, cSVUtility);
            matcherGenerator.LoadParticipants();
            matcherGenerator.PerformMatch();
            matcherGenerator.NotifyAllParticipants();
            Console.ReadLine();
        }
    }
}
