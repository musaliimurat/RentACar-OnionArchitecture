using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IHashingHelperService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt, out int iterations);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt, int iterations);
        string HashRefreshToken(string refreshToken);
        bool ValidateRefreshToken(string rawToken, string storedHashedToken);
    }
}
