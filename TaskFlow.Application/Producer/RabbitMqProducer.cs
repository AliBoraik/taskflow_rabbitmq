using System.Text;
using RabbitMQ.Client;

namespace TaskFlow.Application.Producer;

public class RabbitMqProducer : IRabbitMqProducer
{

    public async Task SendMessage(string message, string queue)
    {
        var factory = new ConnectionFactory { HostName = "rabbitmq" };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync(queue: queue, durable: false, exclusive: false, autoDelete: false,
            arguments: null);
        
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queue, body: body);
        Console.WriteLine($" [x] Sent {message}");
    }
}