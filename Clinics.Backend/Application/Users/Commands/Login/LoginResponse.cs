using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Identity.Users;
using Domain.Entities.People.Shared;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Commands.Login;

public class LoginResponse
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string JWT { get; set; } = null!;
    public PersonalInfo? PersonalInfo { get; set; } = null;

    public static Result<LoginResponse> GetResponse(User user, string jwt, PersonalInfo? personalInfo = null)
    {
        var response = new LoginResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            JWT = jwt
        };
        if (personalInfo is null)
        {
            if (user.Role != Roles.Admin)
                return Result.Failure<LoginResponse>(IdentityErrors.NotFound);
            response.PersonalInfo = PersonalInfo.Create("admin", "", "").Value;
            return response;
        }
        response.PersonalInfo = personalInfo;
        return response;
    }
}
