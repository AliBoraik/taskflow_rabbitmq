using TaskFlow.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<ConsumerWorker>(); })
    .Build();

host.Run();