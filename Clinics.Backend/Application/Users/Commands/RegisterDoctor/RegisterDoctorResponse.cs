using Domain.Entities.Identity.Users;
using Domain.Entities.People.Doctors;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Commands.RegisterDoctor;

public class RegisterDoctorResponse
{
    public int Id {  get; set; }
    public Doctor Doctor { get; set; } = null!;

    public static Result<RegisterDoctorResponse> GetResponse(DoctorUser doctorUser)
    {
        if (doctorUser is null)
            return Result.Failure<RegisterDoctorResponse>(IdentityErrors.NotFound);

        return new RegisterDoctorResponse
        {
            Id = doctorUser.Id,
            Doctor = doctorUser.Doctor
        };
    }
}
