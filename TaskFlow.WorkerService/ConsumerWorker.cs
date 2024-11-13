using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TaskFlow.Domain;

namespace TaskFlow.WorkerService;

public class ConsumerWorker : BackgroundService
{
    private readonly ILogger<ConsumerWorker> _logger;
    private IChannel _channel = null!;
    private IConnection _connection = null!;
    private ConnectionFactory _connectionFactory = null!;
    

    public ConsumerWorker(ILogger<ConsumerWorker> logger)
    {
        _logger = logger;
    }
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = "rabbitmq"
        };
        _connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
        _channel = await _connection.CreateChannelAsync(cancellationToken: cancellationToken);
        await _channel.QueueDeclareAsync(AppQueues.TestQueue, false, false, false, cancellationToken: cancellationToken);
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
            return Task.CompletedTask;
        };
        await _channel.BasicConsumeAsync(AppQueues.TestQueue, true, consumer, cancellationToken: cancellationToken);
        await Task.CompletedTask;
    }

}