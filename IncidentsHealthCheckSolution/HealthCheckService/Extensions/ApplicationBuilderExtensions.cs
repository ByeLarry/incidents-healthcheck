using HealthChecks.UI;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace HealthCheckService.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void MapCustomHealthChecks(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecksUI(setup =>
            {
                setup.UIPath = "/health-ui";
			});
        }
    }
}
