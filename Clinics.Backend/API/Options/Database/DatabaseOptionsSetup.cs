using Microsoft.Extensions.Options;

namespace API.Options.Database;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{

    private const string _cofigurationSectionName = "DatabaseOptions"; // From appsettings.json

    #region Using ctor DI to access configuration
    private readonly IConfiguration _configuration;
    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        options.ConnectionString = connectionString!; // Not null

        // Get string values from section, and parsing them
        _configuration.GetSection(_cofigurationSectionName).Bind(options);
    }
}
