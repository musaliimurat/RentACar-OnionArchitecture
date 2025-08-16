using RentACar.Application.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace RentACar.Infrastructure.Security.Hashing
{
    public class HashingHelper : IHashingHelperService
    {
        private const int SaltSize = 16; // Size of the salt in bytes
        private const int HashSize = 64; // Size of the hash in bytes (SHA-512)
        private const int Iterations = 200_000; // Number of iterations for PBKDF2

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt, out int iterations)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));
            iterations = Iterations;
            passwordSalt = RandomNumberGenerator.GetBytes(SaltSize);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, iterations, HashAlgorithmName.SHA512);
            passwordHash = pbkdf2.GetBytes(HashSize);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt, int iterations)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));
            if (passwordHash is null || passwordSalt is null) return false;
            if (iterations <= 0) return false;
            if (passwordHash.Length != HashSize) return false;

            using var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, iterations, HashAlgorithmName.SHA512);

            var computedHash = pbkdf2.GetBytes(passwordHash.Length);

            return CryptographicOperations.FixedTimeEquals(computedHash, passwordHash);

        }

        public string HashRefreshToken(string refreshToken)
        {
            using var sha256 = SHA256.Create();
            var tokenBytes = Encoding.UTF8.GetBytes(refreshToken);
            var hashedBytes = sha256.ComputeHash(tokenBytes);
            return Convert.ToBase64String(hashedBytes); // DB-yə bu gedir
        }

        public bool ValidateRefreshToken(string rawToken, string storedHashedToken)
        {
            var hashedTokenBytes = Convert.FromBase64String(HashRefreshToken(rawToken));
            var storedHashBytes = Convert.FromBase64String(storedHashedToken);

            return CryptographicOperations.FixedTimeEquals(hashedTokenBytes, storedHashBytes);
        }
    }
}
