using System.Net;
using B39.ScanChain.Application.Exceptions;

namespace B39.ScanChain.Host.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger
)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception: {Message} at {Path}", ex.Message, context.Request.Path);

            var response = context.Response;
            var errResponse = new ErrorHandlerResponse();
            switch (ex)
            {
                case AppException e:
                    response.StatusCode = (int)e.StatusCode;
                    errResponse.Error.Code = e.ErrorCode;
                    errResponse.Error.Message = ex.Message;
                    break;
                default:
                    errResponse.Error.Code = "999";
                    errResponse.Error.Message = ex.Message;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            await context.Response.WriteAsJsonAsync(errResponse);
        }
    }
}