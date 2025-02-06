
using HealthCheckService.Options;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace SearchService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
			

			services.AddHealthChecksUI().AddInMemoryStorage();

			var rabbitMqOptions = configuration.GetSection("RabbitMQOptions").Get<RabbitMQOptions>();

			if (rabbitMqOptions is null)
				throw new ArgumentNullException(nameof(rabbitMqOptions));

			services
				.AddSingleton<IConnection>(sp =>
				{
					Console.WriteLine($"amqp://{rabbitMqOptions.UserName}:{rabbitMqOptions.Password}@{rabbitMqOptions.HostName}");
					var factory = new ConnectionFactory
					{
						Uri = new Uri($"amqp://{rabbitMqOptions.UserName}:{rabbitMqOptions.Password}@{rabbitMqOptions.HostName}")
					};
					return factory.CreateConnectionAsync().GetAwaiter().GetResult();
				})
				.AddHealthChecks()
				.AddRabbitMQ();
			return services;
        }
    }
}
