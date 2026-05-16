using System.Net;
using static DataStore.Abstraction.Utilities.CustomExceptions;

namespace get.Knowledge.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (APIException ex)
            {
                await HandleExceptionAsync(context, ex, ex.StatusCode ?? HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode status)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            Console.WriteLine(ex);
            var response = new { statusCode = context.Response.StatusCode, message = ex.Message };
            await context.Response.WriteAsJsonAsync(response);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
