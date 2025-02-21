using Microsoft.Extensions.Configuration;
using System.Text;

public class BasicAuthMiddleware
{
	private readonly RequestDelegate _next;
	private readonly string _username;
	private readonly string _password;

	public BasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
	{
		_next = next;
		_username = configuration["BasicAuth:Username"];
		_password = configuration["BasicAuth:Password"];
	}

	public async Task Invoke(HttpContext context)
	{
		if (context.Request.Path.StartsWithSegments("/health-ui"))
		{
			string authHeader = context.Request.Headers["Authorization"];
			if (authHeader != null && authHeader.StartsWith("Basic"))
			{
				var encodedCredentials = authHeader.Split(' ')[1];
				var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':');

				if (credentials.Length == 2 &&
					credentials[0] == _username &&
					credentials[1] == _password)
				{
					await _next(context);
					return;
				}
			}

			context.Response.Headers["WWW-Authenticate"] = "Basic";
			context.Response.StatusCode = StatusCodes.Status401Unauthorized;
			return;
		}

		await _next(context);
	}
}
