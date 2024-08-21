using Application.Users.Commands.RegisterDoctor;
using Domain.Entities.Identity.Users;
using Domain.Entities.People.Doctors;
using Domain.Entities.People.Shared;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Commands.RegisterReceptionist;

public class RegisterReceptionistResponse
{
    public int Id { get; set; }
    public PersonalInfo PersonalInfo { get; set; } = null!;

    public static Result<RegisterReceptionistResponse> GetResponse(ReceptionistUser receptionistUser)
    {
        if (receptionistUser is null)
            return Result.Failure<RegisterReceptionistResponse>(IdentityErrors.NotFound);

        return new RegisterReceptionistResponse
        {
            Id = receptionistUser.Id,
            PersonalInfo = receptionistUser.PersonalInfo
        };
    }
}
