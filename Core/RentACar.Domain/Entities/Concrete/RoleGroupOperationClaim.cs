using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class RoleGroupOperationClaim : BaseEntity
    {
        public Guid RoleGroupId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
