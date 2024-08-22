using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Queries.GetAllDoctorUsers;

public class GetAllDoctorUsersResponse
{
    public class GetAllDoctorUsersResponseItem
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }

    public ICollection<GetAllDoctorUsersResponseItem> DoctorUsers { get; set; } = [];


    public static Result<GetAllDoctorUsersResponse> GetResponse(ICollection<DoctorUser> doctorUsers)
    {
        List<GetAllDoctorUsersResponseItem> result = new();
        foreach (var doctorUser in doctorUsers)
        {
            if (doctorUser.User is null || doctorUser.Doctor.PersonalInfo is null)
                return Result.Failure<GetAllDoctorUsersResponse>(PersistenceErrors.NotFound);
            var doctorUserItem = new GetAllDoctorUsersResponseItem
            {
                FullName = doctorUser.Doctor.PersonalInfo.FullName,
                UserName = doctorUser.User.UserName
            };
            result.Add(doctorUserItem);
        }
        return new GetAllDoctorUsersResponse
        {
            DoctorUsers = result
        };
    }
}
