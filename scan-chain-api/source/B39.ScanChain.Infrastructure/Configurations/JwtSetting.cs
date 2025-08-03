namespace B39.ScanChain.Infrastructure.Configurations;

public class JwtSetting
{
    public string SecretKey { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;

    // nên dùng int thay vì string vì bạn muốn thao tác số ngày
    public int Expires { get; set; }         // access token expiry in minutes/days
    public int RefreshExpires { get; set; }  // refresh token expiry in days
}