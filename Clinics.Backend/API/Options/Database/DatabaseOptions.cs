namespace API.Options.Database;

public class DatabaseOptions
{
    // Must match keys in appsettings.json
    public string ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
}
