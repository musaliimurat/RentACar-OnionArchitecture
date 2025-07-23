using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class AppUserRoleGroup : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public Guid RoleGroupId { get; set; }
    }
}
