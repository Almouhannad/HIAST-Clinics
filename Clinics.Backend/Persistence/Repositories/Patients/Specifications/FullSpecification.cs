using Domain.Entities.People.Patients;
using Persistence.Repositories.Specifications.Base;
using System.Linq.Expressions;

namespace Persistence.Repositories.Patients.Specifications;

public class FullSpecification : Specification<Patient>
{
    public FullSpecification(Expression<Func<Patient, bool>>? criteria) : base(criteria)
    {
        AddInclude(patient => patient.PersonalInfo);
        AddInclude(patient => patient.Gender);
    }
}
