using System;
using home_swap_api.Helpers;
using System.Diagnostics;

namespace home_swap_api.Middlewares
{
	public class LoggingMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly LoggerService _logger;

        public LoggingMiddleware(RequestDelegate next, LoggerService logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            // Log information about the request
            _logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} received.");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Call the next middleware in the pipeline
            await _next(context);

            stopwatch.Stop();

            // Log information about the request execution time
            _logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} completed in {stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}

