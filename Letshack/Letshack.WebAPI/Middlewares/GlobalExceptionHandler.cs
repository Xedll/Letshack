using Letshack.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Letshack.WebAPI.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    private static readonly string ContentType = "text/plain";
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception.Message);
        switch (exception)
        {
            case NotFoundException:
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                httpContext.Response.ContentType = ContentType;
                await httpContext.Response.WriteAsync("not found", cancellationToken);
                break;
            default:
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = ContentType;
                await httpContext.Response.WriteAsync("internal server error", cancellationToken);
                break;
        }
        return true;
    }
}