using Application.Abstractions.CQRS.Queries;

namespace Application.Doctors.Queries.GetStatusByUserId;

public class GetDoctorStatusByUserIdQuery : IQuery<GetDoctorStatusByUserIdResponse>
{
    public int UserId { get; set; }
}
