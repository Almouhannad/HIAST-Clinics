using Domain.Shared;

namespace Domain.Errors;

public class APIErrors
{
    public static Error NoData =>
        new("APIError.NoData", "API gave no data");

    public static Error UnableToConnect =>
        new("APIError.UnableToConnect", "Unable to connect to API");
}
