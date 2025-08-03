using System.Net;
using B39.ScanChain.Application.Exceptions;

namespace B39.ScanChain.HttpApi.Middlewares;

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
            logger.LogError(ex, "Unhandled exception occurred while processing request: {Path}", context.Request.Path);

            var response = context.Response;
            var errResponse = new ErrorHandlerResponse();
            response.ContentType = "application/json";
            switch (ex)
            {
                case AppException e:
                    response.StatusCode = (int)e.StatusCode;
                    errResponse.Error.Code = e.ErrorCode;
                    errResponse.Error.Message = ex.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}