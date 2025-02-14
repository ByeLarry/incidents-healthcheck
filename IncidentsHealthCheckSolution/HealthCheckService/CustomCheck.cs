using Microsoft.Extensions.Diagnostics.HealthChecks;

public class CustomCheck : IHealthCheck
{
	public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
	{
		bool isHealthy = true; // Здесь можно выполнить свою логику проверки

		if (isHealthy)
		{
			return Task.FromResult(HealthCheckResult.Healthy("Система работает корректно"));
		}
		else
		{
			return Task.FromResult(HealthCheckResult.Unhealthy("Обнаружены проблемы"));
		}
	}
}
