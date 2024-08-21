using Domain.Entities.Identity.Users;
using Domain.Entities.People.Shared;

namespace Application.Abstractions.JWT;

public interface IJWTProvider
{
    string Generate(User user, PersonalInfo? personalInfo = null);
}
