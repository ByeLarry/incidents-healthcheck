﻿using HealthCheckService.Options;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using RabbitMQ.Client;

namespace SearchService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
			
			services.AddHealthChecksUI()
				.AddInMemoryStorage();

			var rabbitMqOptions = configuration.GetSection("RabbitMQOptions").Get<RabbitMQOptions>();
			var elasticsearchOptions = configuration.GetSection("ElasticsearchOptions").Get<ElasticsearchOptions>();
			var redisConnectionString = configuration.GetValue<string>("Redis:ConnectionString");
			var mongoDbConnectionString = configuration.GetValue<string>("MongoDB:ConnectionString");
			var pgSqlConnectionString = configuration.GetValue<string>("Postgres:ConnectionString");

			if (rabbitMqOptions is null)
				throw new ArgumentNullException(nameof(rabbitMqOptions));

			if (elasticsearchOptions is null)
				throw new ArgumentNullException(nameof(elasticsearchOptions));

			if (string.IsNullOrEmpty(redisConnectionString))
				throw new ArgumentNullException(nameof(redisConnectionString));

			if (string.IsNullOrEmpty(mongoDbConnectionString))
				throw new ArgumentNullException(nameof(mongoDbConnectionString));

			if (string.IsNullOrEmpty(pgSqlConnectionString))
				throw new ArgumentNullException(nameof(pgSqlConnectionString));

			services
				.AddSingleton<IConnection>(sp =>
				{
					var factory = new ConnectionFactory
					{
						Uri = new Uri($"amqp://{rabbitMqOptions.UserName}:{rabbitMqOptions.Password}@{rabbitMqOptions.HostName}")
					};
					return factory.CreateConnectionAsync().GetAwaiter().GetResult();
				})
				.AddSingleton<IMongoClient>(sp =>
				{
					var client = new MongoClient(mongoDbConnectionString);

					return client;
				})
				.AddHealthChecks()
				.AddDiskStorageHealthCheck(options =>
				{
					options.AddDrive("/", 1024); 
				}, name: "disk", tags: new[] { "health-checks" })
				.AddUrlGroup(new Uri("http://localhost:7070"), name: "self", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks" })
				.AddProcessAllocatedMemoryHealthCheck(500 * 1024 * 1024, "memory_heap", tags: new[] { "health-checks" }) // Порог 500MB
				.AddWorkingSetHealthCheck(1024 * 1024 * 1024, "memory_rss", tags: new[] { "health-checks" }) // Порог 1GB
				.AddRabbitMQ(name: "RabbitMQ", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks" })
				.AddRedis(redisConnectionString, name: "Redis", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks" })
				.AddMongoDb(name: "MongoDB", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks", "auth"})
				.AddNpgSql(pgSqlConnectionString, name: "Postgres", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks", "marks" })
				.AddElasticsearch(setup: options =>
				{
					options.UseServer(elasticsearchOptions.Uri);
					options.UseBasicAuthentication(elasticsearchOptions.Username, elasticsearchOptions.Password);

				}, name: "Elasticsearch", failureStatus: HealthStatus.Unhealthy, tags: new[] { "health-checks", "search" });

			return services;
		}
	}
}
