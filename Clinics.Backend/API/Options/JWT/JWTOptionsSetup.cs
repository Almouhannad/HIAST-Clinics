using Microsoft.Extensions.Options;
using Persistence.Identity.Authentication.JWT;

namespace API.Options.JWT;

public class JWTOptionsSetup : IConfigureOptions<JWTOptions>
{
    private const string _cofigurationSectionName = "JWTOptions"; // From appsettings.json

    #region Using ctor DI to access configuration
    private readonly IConfiguration _configuration;
    public JWTOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    public void Configure(JWTOptions options)
    {
        _configuration.GetSection(_cofigurationSectionName).Bind(options);
    }
}
