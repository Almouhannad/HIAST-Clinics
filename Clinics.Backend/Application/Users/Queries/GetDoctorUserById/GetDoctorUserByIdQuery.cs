using Application.Abstractions.CQRS.Queries;

namespace Application.Users.Queries.GetDoctorUserById;

public class GetDoctorUserByIdQuery : IQuery<GetDoctorUserByIdResponse>
{
    public int Id { get; set; }
}
