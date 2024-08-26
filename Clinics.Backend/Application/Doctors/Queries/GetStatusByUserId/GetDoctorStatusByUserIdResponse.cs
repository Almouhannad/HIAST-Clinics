using Domain.Entities.People.Doctors;

namespace Application.Doctors.Queries.GetStatusByUserId;

public class GetDoctorStatusByUserIdResponse 
{
    public string Status { get; set; } = null!;

    public static GetDoctorStatusByUserIdResponse GetResponse(Doctor doctor)
    {
        return new GetDoctorStatusByUserIdResponse
        {
            Status = doctor.Status.Name
        };
    }
}
