using Microsoft.AspNetCore.Http.Extensions;

namespace PontoMaisApi.Middlewares.Log
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;
        
        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context){
            _logger.LogInformation($"MIDDLEWARE -- Requested URL: {UriHelper.GetDisplayUrl(context.Request)}");
            await this._next(context);
        }
    }
}