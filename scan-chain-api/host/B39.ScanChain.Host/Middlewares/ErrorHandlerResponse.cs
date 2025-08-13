namespace B39.ScanChain.Host.Middlewares;

public class ErrorHandlerResponse
{
    public ErrorResponse Error { get; } = new();
}

public class ErrorResponse
{
    public string Code { get; set; } = "999";
    public string? Message { get; set; }
    public string? Details { get; set; }
    public Dictionary<string, string>? Data { get; set; }
    public IEnumerable<string>? ValidationErrors { get; set; }
}