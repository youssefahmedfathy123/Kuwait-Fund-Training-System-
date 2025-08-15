using Application.Abstractions.Auth.RoleManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.RoleManager
{
    public class RemovePermissionFromRoleHandler : ICommandHandler<RemovePermissionFromRoleCommand, Result<string>>
    {
        private readonly IRoleManagerServices _roleManagerServices;
        public RemovePermissionFromRoleHandler(IRoleManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        public async Task<Result<string>> Handle(RemovePermissionFromRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.RemovePermissionFromRole(request.RoleName, request.PermissionName);
        }
    }

}



