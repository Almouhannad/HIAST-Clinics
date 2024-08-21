using System.Security.Cryptography;

namespace Persistence.Identity.PasswordsHashing;

public class PasswordHasher : IPasswordHasher
{
    #region Hashing
    // Salting is adding a random number to the hash
    // to ensure that users with same passwords have
    // different hash values.
    // Best pactice is to use 128 bits = 16 bytes
    private const int SaltSize = 16;

    // Output size
    // Best practice is to use 256 bits
    private const int HashSize = 32;

    private const int Iterations = 100000;

    private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
        // Pdkdf ~ Password Based Key Derivation Function

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }
    #endregion

    #region Verification
    public bool Verify(string password, string passwordHash)
    {
        string[] parts = passwordHash.Split('-');

        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
    #endregion

}
