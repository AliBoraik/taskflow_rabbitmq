namespace TaskFlow.Interfaces;

public interface IRabbitMqService
{
    void SendMessage(string message);
}