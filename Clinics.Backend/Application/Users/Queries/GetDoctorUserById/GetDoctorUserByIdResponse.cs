using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Queries.GetDoctorUserById;

public class GetDoctorUserByIdResponse
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public static Result<GetDoctorUserByIdResponse> GetResponse (DoctorUser doctorUser)
    {
        if (doctorUser.Id <= 0 || doctorUser.User is null || doctorUser.Doctor is null)
            return Result.Failure<GetDoctorUserByIdResponse>(PersistenceErrors.NotFound);
        if (doctorUser.Doctor.PersonalInfo is null)
            return Result.Failure<GetDoctorUserByIdResponse>(PersistenceErrors.NotFound);

        return new GetDoctorUserByIdResponse
        {
            Id = doctorUser.Id,
            UserName = doctorUser.User.UserName,
            FirstName = doctorUser.Doctor.PersonalInfo.FirstName,
            MiddleName = doctorUser.Doctor.PersonalInfo.MiddleName,
            LastName = doctorUser.Doctor.PersonalInfo.LastName,
        };
    }
}
