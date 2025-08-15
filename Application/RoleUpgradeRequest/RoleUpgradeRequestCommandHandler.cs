using Application.Abstractions.RoleUpgradeRequest;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RoleUpgradeRequest
{
    public class RoleUpgradeRequestCommandHandler : ICommandHandler<RoleUpgradeRequestCommand, Result<string>>
    {
        private readonly IRoleUpgradeRequestServices _roleUpgradeRequestServices;
        public RoleUpgradeRequestCommandHandler(IRoleUpgradeRequestServices roleUpgradeRequestServices)
        {
            _roleUpgradeRequestServices = roleUpgradeRequestServices;
        }
        public Task<Result<string>> Handle(RoleUpgradeRequestCommand request, CancellationToken cancellationToken)
        {
           return _roleUpgradeRequestServices.Add(request.userId, request.requestedRole,cancellationToken);
        }
    }
}


