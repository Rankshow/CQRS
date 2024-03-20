namespace CQRS.Middlewares;

public class ErrorHandlerMiddleware
{
    readonly ILogger<ErrorHandlerMiddleware> _logger;
    readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {

            Dictionary<string, string[]> errors = new()
            {
                {"Error", new string[] {error.Message} }
            };
            if (error.InnerException != null)
            {
                _logger.LogError(error.InnerException.Message);
                errors.Add("InnerException", new string[] { error.InnerException.Message });
            }
            var response = context.Response;
            response.
        }
    }
}
