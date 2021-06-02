using System;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMQConsume consumer1 = new RabbitMQConsume("localhost", "jk.direct.queue1");
            RabbitMQConsume consumer2 = new RabbitMQConsume("localhost", "jk.direct.queue2");

            consumer1.ConsumeMessage();
            consumer2.ConsumeMessage();
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
            consumer1.CloseConnection();
            consumer2.CloseConnection();
        }
    }
}
