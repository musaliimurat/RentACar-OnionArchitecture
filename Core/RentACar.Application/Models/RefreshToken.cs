using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Models
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && Expiration > DateTime.UtcNow;
    }
}
