

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost",
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("example", exclusive: false, autoDelete: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += Received;
channel.BasicConsume(queue: "example", consumer:consumer);
Console.ReadLine();

void Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    System.Console.WriteLine($"Recives:{message}");
}