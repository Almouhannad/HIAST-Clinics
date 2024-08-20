namespace Persistence.Identity.PasswordsHashing;

public interface IPasswordHasher
{
    public string Hash(string password);

    public bool Verify(string password, string passwordHash);
}
