using Domain.Entities.Identity.Users;

namespace Application.Abstractions.JWT;

public interface IJWTProvider
{
    string Generate(User user);
}
