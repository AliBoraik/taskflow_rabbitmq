using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Producer;
using TaskFlow.Interfaces;

namespace TaskFlow.Application.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
        services.AddScoped<IRabbitMqService, RabbitMqService>();
        return services;
    }
}