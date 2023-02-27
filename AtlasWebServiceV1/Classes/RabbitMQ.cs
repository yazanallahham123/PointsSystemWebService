using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class RabbitMQ
    {


    }



    class Send
    {
        public static void Main()
        {


            var factory = new ConnectionFactory()
            {
                HostName = "192.95.33.64",
                UserName = "techno",
                Password = "techno",
                VirtualHost = "/",
                Port = AmqpTcpEndpoint.UseDefaultPort
                //Protocol = Protocols.AMQP_0_9_1
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "world", durable: true, exclusive: false, autoDelete: false, arguments: null);

                string message = "{\"HelloWorld\":\"test\"}";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "world", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}