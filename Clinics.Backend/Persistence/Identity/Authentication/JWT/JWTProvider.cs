using Application.Abstractions.JWT;
using Domain.Entities.Identity.Users;
using Domain.Entities.People.Shared;
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

    public string Generate(User user, PersonalInfo? personalInfo = null)
    {
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new("userName", user.UserName),
            new("role", user.Role.Name)
        };

        if (personalInfo is not null)
        {
            claims.Add(new Claim("fullName", personalInfo.FullName));
        }

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims.ToArray(),
            null,
            DateTime.UtcNow.AddDays(30),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
