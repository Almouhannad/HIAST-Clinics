using Domain.Entities.People.Doctors;
using Persistence.Repositories.Specifications.Base;
using System.Linq.Expressions;

namespace Persistence.Repositories.Doctors.Specifications;

public class FullDoctorSpecification : Specification<Doctor>
{
    public FullDoctorSpecification(Expression<Func<Doctor, bool>>? criteria) : base(criteria)
    {
        AddInclude(doctor => doctor.PersonalInfo);
        AddInclude(doctor => doctor.Status);
        AddInclude(doctor => doctor.Phones);
    }
}
