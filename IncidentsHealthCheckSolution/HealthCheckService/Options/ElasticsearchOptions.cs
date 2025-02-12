namespace HealthCheckService.Options
{
	public class ElasticsearchOptions
	{
		public required string Uri { get; set; }
		public required string Username { get; set; }
		public required string Password { get; set; }
	}
}
