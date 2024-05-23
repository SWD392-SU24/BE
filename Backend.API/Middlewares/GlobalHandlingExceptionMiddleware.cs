using Backend.BO.Commons;
using System.Net;

namespace Backend.API.Middlewares
{
    public class GlobalHandlingExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles the exception and sets the appropriate status code and response.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="ex">The exception to handle.</param>
        /// <returns>A task that represents the asynchronous exception handling operation.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case InvalidOperationException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case NotSupportedException:
                    statusCode = HttpStatusCode.NotImplemented;
                    break;
                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            // Return a JSON response with the error message
            context.Response.ContentType = "application/json";

            var response = new ResponseModel<string>(
                statusCode: (int)statusCode,
                message: ex.Message,
                response: null
            );
            //var response = new DetailedError()
            //{
            //    StatusCode = (int)statusCode,
            //    Message = ex.Message
            //};
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}

