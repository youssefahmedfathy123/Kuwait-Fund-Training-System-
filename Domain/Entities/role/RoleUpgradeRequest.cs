using Domain.DomainEvents;
using Domain.Primitives;

namespace Domain.Entities.role
{
    public sealed class RoleUpgradeRequest : AggragateRoot<Guid>
    {
        public string UserId { get; private set; }
        public string RequestedRole { get; private set; } 
        public RoleUpgradeRequestStatus Status { get; private set; }


        private RoleUpgradeRequest() { }

        public RoleUpgradeRequest(string userId, string requestedRole)
        {
            UserId = userId;
            RequestedRole = requestedRole;
            Status = RoleUpgradeRequestStatus.Pending;
        }


        public void Approve(string email,string username,string requestedRole)
        {
            if (Status != RoleUpgradeRequestStatus.Pending)
                throw new InvalidOperationException("Request already processed.");

            Status = RoleUpgradeRequestStatus.Approved;

            RaiseDomainEvent(new ApprovedOrRejectedRoleUpgradeRequestDomainEvent(email,username,requestedRole,Status));

        }


        public void Reject(string email, string username,string requestedRole)
        {
            if (Status != RoleUpgradeRequestStatus.Pending)
                throw new InvalidOperationException("Request already processed.");

            Status = RoleUpgradeRequestStatus.Rejected;

            RaiseDomainEvent(new ApprovedOrRejectedRoleUpgradeRequestDomainEvent(email, username, requestedRole, Status));

        }


    }



    public enum RoleUpgradeRequestStatus
    {
        Pending = 1,
        Approved,
        Rejected
    }

}


