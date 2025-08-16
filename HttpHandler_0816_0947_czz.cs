// 代码生成时间: 2025-08-16 09:47:00
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HttpHandlerDemo
{
    /// <summary>
    /// A simple HTTP request handler.
    /// </summary>
    public class HttpHandler
    {
        private readonly ILogger<HttpHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public HttpHandler(ILogger<HttpHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles an HTTP request and produces a response.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>A task that completes with the handling of the request.</returns>
        public async Task HandleRequestAsync(HttpContext httpContext)
        {
            try
            {
                // Check if the request is a GET request.
                if (httpContext.Request.Method == HttpMethods.Get)
                {
                    // Handle GET request.
                    await HandleGetRequestAsync(httpContext);
                }
                else if (httpContext.Request.Method == HttpMethods.Post)
                {
                    // Handle POST request.
                    await HandlePostRequestAsync(httpContext);
                }
                else
                {
                    // Handle other methods.
                    HandleOtherRequestMethod(httpContext);
                }
            }
            catch (Exception ex)
            {
                // Log the error and set the response status to 500.
                _logger.LogError(ex, "Error handling HTTP request.");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }

        private async Task HandleGetRequestAsync(HttpContext httpContext)
        {
            // Set the response content type.
            httpContext.Response.ContentType = "text/plain";
            // Write a simple response.
            await httpContext.Response.WriteAsync("GET request received.
");
        }

        private async Task HandlePostRequestAsync(HttpContext httpContext)
        {
            // Set the response content type.
            httpContext.Response.ContentType = "text/plain";
            // Read the body of the request.
            string requestBody = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
            // Write a simple response.
            await httpContext.Response.WriteAsync($"POST request received with body: {requestBody}
");
        }

        private void HandleOtherRequestMethod(HttpContext httpContext)
        {
            // Set the response status code to 405 (Method Not Allowed).
            httpContext.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
        }
    }
}