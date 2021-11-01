using GiftExchangeProblem.Interface;
using System;


namespace GiftExchangeProblem
{
    public class ConsoleNotification : INotificationService
    {
        public void Notify(Participant participant)
        {
            Console.WriteLine($"{participant.EmailAddress}->{participant.Sender.EmailAddress}");
        }
    }
}
