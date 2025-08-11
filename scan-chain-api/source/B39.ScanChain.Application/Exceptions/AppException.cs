using System.Net;

namespace B39.ScanChain.Application.Exceptions;

public class AppException(string errorCode = "999", HttpStatusCode statusCode = HttpStatusCode.Forbidden) : Exception
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string ErrorCode { get; } = errorCode;
}