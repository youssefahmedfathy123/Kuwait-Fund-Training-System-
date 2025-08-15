using Application.Abstractions.Auth.UserManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.UserManager
{
    class RemovePermissionFromUserCommandHandler : ICommandHandler<RemovePermissionFromUserCommand, Result<string>>
    {
        private readonly IUserManagerServices _roleManagerServices;

        public RemovePermissionFromUserCommandHandler(IUserManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        public async Task<Result<string>> Handle(RemovePermissionFromUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.RemovePermissionFromUser(request.username, request.permissionName);
        }
    }
}


