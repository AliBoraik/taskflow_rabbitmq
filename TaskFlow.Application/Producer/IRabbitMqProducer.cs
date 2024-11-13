namespace TaskFlow.Application.Producer;

public interface IRabbitMqProducer
{
    Task SendMessage(string message, string queue);
}