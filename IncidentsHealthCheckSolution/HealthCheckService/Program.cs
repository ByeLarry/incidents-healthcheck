using HealthCheckService.Extensions;
using RabbitMQ.Client;
using SearchService.Extensions;
using Microsoft.AspNetCore.Authentication;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddAuthorization();

		builder.Services.AddCustomHealthChecks(builder.Configuration);

		var app = builder.Build();

		app.UseMiddleware<BasicAuthMiddleware>();

		app.MapGet("/", () => Results.Ok("Service is up and running"));

		app.MapCustomHealthChecks(builder.Configuration);

		app.Run();
	}
}
