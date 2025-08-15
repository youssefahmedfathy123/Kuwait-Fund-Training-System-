using Application.Abstractions.Auth.RoleManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.RoleManager
{
    public class AddPermissionToRoleCommandHandler : ICommandHandler<AddPermissionToRoleCommand, Result<string>>
    {
        private readonly IRoleManagerServices _roleManagerServices;
        public AddPermissionToRoleCommandHandler(IRoleManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }
        public async Task<Result<string>> Handle(AddPermissionToRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.AddPermissionToRole(request.RoleName, request.PermissionName);
        }
    }
}



