using Domain.Shared;

namespace Domain.Errors;

public static class IdentityErrors
{
    public static Error InvalidRole => new("Identity.InvalidRole", "Role specified for user is invalid");
}
