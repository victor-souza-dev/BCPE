using System.Net;
using System.Text.Json;

namespace ExtractCssValuesToJson.Middlewares; 
public class ErrorMiddleware {
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        var statusCode = HttpStatusCode.BadRequest;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var errorResponse = new ErrorResponse {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}

public class ErrorResponse {
    public int StatusCode { get; set; }
    public string Message { get; set; }
}