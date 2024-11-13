using TaskFlow.Application.Producer;
using TaskFlow.Domain;
using TaskFlow.Interfaces;

namespace TaskFlow.Application;

public class RabbitMqService : IRabbitMqService
{
    private readonly IRabbitMqProducer _rabbitMqProducer;

    public RabbitMqService(IRabbitMqProducer rabbitMqProducer)
    {
        _rabbitMqProducer = rabbitMqProducer;
    }

    public void SendMessage(string message)
    {
        _rabbitMqProducer.SendMessage(message, AppQueues.TestQueue);
    }
}