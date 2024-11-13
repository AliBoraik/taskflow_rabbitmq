using TaskFlow.Application.Producer;

namespace TaskFlow.Application.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
        return services;
    }
}