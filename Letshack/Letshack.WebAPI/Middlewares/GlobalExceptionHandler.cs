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
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = ContentType;
                await httpContext.Response.WriteAsync("invalid request", cancellationToken);
                break;
            case InvalidTechnologyIdException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = ContentType;
                await httpContext.Response.WriteAsync("invalid technology id", cancellationToken);
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