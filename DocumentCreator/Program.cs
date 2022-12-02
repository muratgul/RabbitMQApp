using DocumentCreator.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DocumentCreator
{
    internal class Program
    {
        static IConnection connection;
        private readonly static string createDocument = "create_document_queue";
        private readonly static string documentCreated = "document_created_queue";
        private readonly static string documentCreateExchange = "document_created_exchange";

        static IModel _channel;
        static IModel channel => _channel ?? (_channel = GetChannel());
        static void Main(string[] args)
        {
            connection = GetConnection();

            channel.ExchangeDeclare(documentCreateExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreateExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreateExchange, documentCreated);

            var consumerEvent = new EventingBasicConsumer(channel);
            
            consumerEvent.Received += (ch, ea) =>
            {
                var modelJson = Encoding.UTF8.GetString(ea.Body.ToArray());
                var model = JsonConvert.DeserializeObject<CreateDocumentModel>(modelJson);
                Console.WriteLine($"Received Data: {modelJson}");

                // Create Document

                Task.Delay(5000).Wait();

                model.Url = "http://edevlet.com/pdf/dosya.pdf";

                WriteQueue(documentCreated, model);
            };

            channel.BasicConsume(createDocument, true, consumerEvent);

            Console.WriteLine($"{documentCreateExchange} listening");

            Console.ReadLine();
        }

        private static void WriteQueue(string queueName, CreateDocumentModel model)
        {
            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            channel.BasicPublish(documentCreateExchange, queueName, null, messageArray);

            Console.WriteLine("Message published");
        }
        private static IModel GetChannel()
        {
            return connection.CreateModel();
        }
        private static IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            return connectionFactory.CreateConnection();
        }
    }
}
