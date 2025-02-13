using HealthCheckService.Extensions;
using RabbitMQ.Client;
using SearchService.Extensions;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateSlimBuilder(args);

		builder.Services.AddCustomHealthChecks(builder.Configuration);

		var app = builder.Build();

		app.MapCustomHealthChecks();

		app.Run();
	}
}