using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQConsumer
{
    class RabbitMQConsume
    {
        ConnectionFactory connectionFactory;
        IConnection connection;
        IModel channel;
        string queueName;

        public RabbitMQConsume(string hostName, string queueName)
        {
            connectionFactory = new ConnectionFactory()
            {
                HostName = hostName,
                UserName = "guest",
                Password = "guest"
            };
            connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            this.queueName = queueName;

        }
        public bool ConsumeMessage()
        {
            try
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var messageBody = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(messageBody);
                    Message msg = JsonConvert.DeserializeObject<Message>(message);
                    Console.WriteLine($"Message received from Queue - {queueName}");
                    Console.WriteLine("****Message details****");
                    Console.WriteLine($"Title : {msg.MessageTitle}");
                    Console.WriteLine($"Description : {msg.MessageDescription}");
                    Console.WriteLine($"From : {msg.MessageGeneratedBy}");
                    Console.WriteLine($"Created At : {msg.MessageGeneratedAt}");
                    Console.WriteLine("****Message details completed****");
                };

                channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failure in reading message from RabbitMQ - Queue : {queueName} Exception : {ex.ToString()}");
                return false;
            }
        }

        public void CloseConnection()
        {
            channel.Close();
            connection.Close();
        }
    }
}
