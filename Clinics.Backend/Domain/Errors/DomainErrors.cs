using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static Error InvalidValuesError => new Error("Domain.InvalidValues", "Given values are invalid!");
}
