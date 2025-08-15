using Application.Abstractions.RoleUpgradeRequest;
using Application.Message;
using Gatherly.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApproveOrRejectRoleUpgradeRequest
{
    public class ApproveOrRejectRoleUpgradeRequestCommandHandler :
        ICommandHandler<ApproveOrRejectRoleUpgradeRequestCommand, Result<string>>
    {

        private readonly IRoleUpgradeRequestServices _roleUpgradeRequestRepository;
        public ApproveOrRejectRoleUpgradeRequestCommandHandler(IRoleUpgradeRequestServices roleUpgradeRequestRepository)
        {
            _roleUpgradeRequestRepository = roleUpgradeRequestRepository;
        }
        public async Task<Result<string>> Handle(ApproveOrRejectRoleUpgradeRequestCommand request, CancellationToken cancellationToken)
        {
            return await _roleUpgradeRequestRepository.ApproveOrReject(request.RequestId, request.IsApproved,cancellationToken);
        }
    }
}



