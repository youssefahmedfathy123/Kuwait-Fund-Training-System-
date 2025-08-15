using Domain.Entities.role;
using Domain.Primitives;

namespace Domain.DomainEvents;
    public sealed record ApprovedOrRejectedRoleUpgradeRequestDomainEvent(
                string email,
                string userName,
                string requestedRole,
                RoleUpgradeRequestStatus status
        )
    : IDomainEvent;




