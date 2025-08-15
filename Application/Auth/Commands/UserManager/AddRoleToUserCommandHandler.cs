using Application.Abstractions.Auth.UserManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.UserManager
{
    public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand, Result<string>>
    {
        private readonly IUserManagerServices _roleManagerServices;

        public AddRoleToUserCommandHandler(IUserManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        public async Task<Result<string>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.AddRoleToUser(request.username, request.rolename);
        }
    }
}


