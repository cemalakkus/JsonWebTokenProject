using System.Net;

namespace ApiKeyProject.Middleware
{
    //Custom Middleware
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Headers["ApiKey"]))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }
            string? userApiKey = context.Request.Headers["ApiKey"];

            if (string.IsNullOrWhiteSpace(userApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            string? apiKey = _configuration.GetValue<string>("ApiKey");

            if (apiKey == null || apiKey != userApiKey)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
