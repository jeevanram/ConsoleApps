using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQPublisher
{
    class RabbitMQPublish
    {
        ConnectionFactory connectionFactory;

        public RabbitMQPublish(string hostName)
        {
            connectionFactory = new ConnectionFactory()
            {
                HostName = hostName,
                UserName = "guest",
                Password = "guest"
            };
        }
        public bool PublishMessage(string exchangeName, string routingKey, Message message)
        {
            try
            {
                using (var connection = connectionFactory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.BasicPublish(exchange: exchangeName,
                            routingKey: routingKey,
                            basicProperties: null,
                            body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
                    }
                }
                Console.WriteLine("Message successfully published to RabbitMQ");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message not published to RabbitMQ. Exception - {ex.ToString()}");
                return false;
            }
        }
    }
}
