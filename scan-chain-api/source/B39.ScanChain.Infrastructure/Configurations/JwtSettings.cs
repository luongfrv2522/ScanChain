namespace B39.ScanChain.Infrastructure.Configurations;

public class JwtSettings
{
    public string SecretKey { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;

    public int Expires { get; set; }         // access token expiry in minutes/days
    public int RefreshExpires { get; set; }  // refresh token expiry in days
}