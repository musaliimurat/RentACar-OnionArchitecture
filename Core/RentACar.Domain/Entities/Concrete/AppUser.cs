using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class AppUser : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool Status { get; set; }
        public bool IsLogin { get; set; } = false;
        public string? HashedRefreshToken { get; set; }
        public DateTime? HashedRefreshTokenExpiration { get; set; }
        public string? HashedResetPasswordToken { get; set; }
        public DateTime? HashedResetPasswordExpiration { get; set; }
    }
}
