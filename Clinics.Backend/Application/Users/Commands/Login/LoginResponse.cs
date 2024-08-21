using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Identity.Users;
using Domain.Entities.People.Shared;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Commands.Login;

public class LoginResponse
{
    public string JWT { get; set; } = null!;

    public static Result<LoginResponse> GetResponse(string jwt)
    {
        if (jwt is null)
            return Result.Failure< LoginResponse>(IdentityErrors.NotFound);
        var response = new LoginResponse
        {
            JWT = jwt
        };
        return response;
    }
}
