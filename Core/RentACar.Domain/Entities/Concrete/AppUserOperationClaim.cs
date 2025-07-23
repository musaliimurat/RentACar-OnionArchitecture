using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class AppUserOperationClaim : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
