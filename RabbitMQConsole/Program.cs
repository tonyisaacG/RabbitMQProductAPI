// See https://aka.ms/new-console-template for more information
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, RabbitMQ!");



        var connectionFactory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "product", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var my_body = ea.Body.ToArray();
            var info = Encoding.UTF8.GetString(my_body);
            Console.WriteLine(" [x] Received {0}", info);
        };

        channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}