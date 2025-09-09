using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductInventoryApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                // Handle 404 Not Found (when no endpoint matches)
                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound &&
                    !context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    var response = new
                    {
                        success = false,
                        message = "The requested resource was not found."
                    };

                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                success = false,
                message = "An unexpected error occurred.",
                error = ex.Message
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
