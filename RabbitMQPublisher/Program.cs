using System;

namespace RabbitMQPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the message name");
            string messageName = Console.ReadLine();

            Console.WriteLine("Enter the message description");
            string messageDescription = Console.ReadLine();

            Console.WriteLine("Enter the message sent by");
            string messageSentBy = Console.ReadLine();

            Message msg = new Message()
            {
                MessageTitle = messageName,
                MessageDescription = messageDescription,
                MessageGeneratedBy = messageSentBy,
                MessageGeneratedAt = DateTime.UtcNow
            };
            RabbitMQPublish rabbitMQPublish = new RabbitMQPublish("localhost");
            rabbitMQPublish.PublishMessage("jk.direct", "queue2", msg);

            Console.ReadLine();
        }
    }
}
