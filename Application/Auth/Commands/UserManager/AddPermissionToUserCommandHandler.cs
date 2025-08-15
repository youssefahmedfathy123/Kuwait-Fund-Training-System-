using Application.Abstractions.Auth.RoleManagerS;
using Application.Abstractions.Auth.UserManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.UserManager
{
    public class AddPermissionToUserCommandHandler : ICommandHandler<AddPermissionToUserCommand, Result<string>>
    {
        private readonly IUserManagerServices _roleManagerServices;

        public AddPermissionToUserCommandHandler(IUserManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        public async Task<Result<string>> Handle(AddPermissionToUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.AddPermissionToUser(request.username, request.permissionName);
        }
    }
}


