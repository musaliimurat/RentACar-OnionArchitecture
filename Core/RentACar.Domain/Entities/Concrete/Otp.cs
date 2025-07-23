using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class Otp : BaseEntity
    {
        public string Email { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; }
    }
}
