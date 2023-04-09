using Newtonsoft.Json;
using Zahradneek.Api.Exceptions;

namespace Zahradneek.Api.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context: context, ex: ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = GetStatusCode(ex);

        var exceptionResult = JsonConvert.SerializeObject(new
        {
            message = ex.Message,
        });
        return context.Response.WriteAsync(exceptionResult);
    }

    private static int GetStatusCode(Exception ex)
    {
        return ex.GetType() switch
        {
            { } t when t == typeof(NotFoundException) => StatusCodes.Status404NotFound,
            { } t when t == typeof(ValidationException) => StatusCodes.Status400BadRequest,
            { } t when t == typeof(IncorrectCredentialsException) => StatusCodes.Status400BadRequest,
            { } t when t == typeof(DbConflictException) => StatusCodes.Status409Conflict,
            { } t when t == typeof(ConflictException) => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}