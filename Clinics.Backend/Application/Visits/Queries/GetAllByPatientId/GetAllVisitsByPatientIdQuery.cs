using Application.Abstractions.CQRS.Queries;

namespace Application.Visits.Queries.GetAllByPatientId;

public class GetAllVisitsByPatientIdQuery : IQuery<GetAllVisitsByPatientIdResponse>
{
    public int PatientId { get; set; }
}
