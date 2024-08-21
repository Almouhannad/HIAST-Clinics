using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Identity.Authentication.JWT;
using System.Text;

namespace API.Options.JWT;

public class JWTBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
{
    #region JWT Options CTOR DI
    private readonly JWTOptions _jwtOptions;

    public JWTBearerOptionsSetup(IOptions<JWTOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    #endregion

    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
        options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
        options.TokenValidationParameters.IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
    }
}
