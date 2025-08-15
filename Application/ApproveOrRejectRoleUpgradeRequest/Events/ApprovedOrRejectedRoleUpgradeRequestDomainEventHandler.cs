using Application.Abstractions.Email.Application.Abstractions.Email;
using Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApproveOrRejectRoleUpgradeRequest.Events
{
    public class ApprovedOrRejectedRoleUpgradeRequestDomainEventHandler :
        INotificationHandler<ApprovedOrRejectedRoleUpgradeRequestDomainEvent>
    {
        private readonly IEmailServices _emailservices;
        public ApprovedOrRejectedRoleUpgradeRequestDomainEventHandler(IEmailServices emailservices)
        {
            _emailservices = emailservices;
        }

        public async Task Handle(ApprovedOrRejectedRoleUpgradeRequestDomainEvent notification, CancellationToken cancellationToken)
        {
            await _emailservices.SendRoleUpgradeStatusEmailAsync(
             notification.email,
             notification.userName,
             notification.requestedRole,
             notification.status,
             cancellationToken);
        }
    }
}


