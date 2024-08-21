using Application.Abstractions.JWT;
using Domain.Entities.Identity.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.Identity.Authentication.JWT;

public sealed class JWTProvider : IJWTProvider
{
    private readonly JWTOptions _options;

    public JWTProvider(IOptions<JWTOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(User user)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role.Name)

        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddDays(30),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
