namespace Persistence.Identity.Authentication.JWT;

// Using option pattern
public class JWTOptions
{
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string SecretKey { get; init; } = null!;
}
