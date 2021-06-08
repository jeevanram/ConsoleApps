using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPublisher
{
    class RedisPub : RedisConnect
    {
        private ISubscriber _publisher { get; set; }

        public RedisPub()
        {
            _publisher = Redis.Multiplexer.GetSubscriber();
        }
        public override void PromptInputConsole()
        {
            Console.WriteLine("Enter the channel to publish : ");
            string channel = Console.ReadLine();
            Console.WriteLine("Enter the message to publish : ");
            Console.WriteLine("Enter message title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter message description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter message sent by:");
            string sentBy = Console.ReadLine();

            Message message = new Message()
            {
                MessageTitle = title,
                MessageDescription = description,
                MessageGeneratedBy = sentBy,
                MessageGeneratedAt = DateTime.UtcNow
            };
            _publisher.Publish(channel, JsonConvert.SerializeObject(message));
        }

        public override void WalkthroughFunctionalities()
        {
            throw new NotImplementedException();
        }
    }
}
