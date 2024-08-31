using Application.Abstractions.CQRS.Queries;

namespace Application.Doctors.Queries.GetPhonesByUserId;

public class GetDoctorPhonesByUserIdQuery : IQuery<GetDoctorPhonesByUserIdResponse>
{
    public int DoctorUserId { get; set; }
}
