using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net;

namespace HealthCheckService.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void MapCustomHealthChecks(this IEndpointRouteBuilder app, IConfiguration configuration)
		{
			var allowedIps = configuration["AllowedIPs"]?.Split(',').Select(ip => ip.Trim()).ToList() ?? new List<string>();

			app.MapHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			app.MapHealthChecksUI(setup =>
			{
				setup.UIPath = "/health-ui";
			}).RequireAuthorization(new AuthorizationPolicyBuilder()
				.RequireAssertion(context =>
				{
					var httpContext = context.Resource as HttpContext;
					var remoteIp = httpContext?.Connection.RemoteIpAddress;

					if (remoteIp == null) return false;

					// Преобразуем IP в строку
					string remoteIpString = remoteIp.ToString();

					// Если разрешен "0.0.0.0", то доступ открыт для всех
					if (allowedIps.Contains("0.0.0.0"))
						return true;

					// Проверяем, входит ли IP в разрешенный список
					return allowedIps.Contains(remoteIpString);
				}).Build());
		}
	}
}
