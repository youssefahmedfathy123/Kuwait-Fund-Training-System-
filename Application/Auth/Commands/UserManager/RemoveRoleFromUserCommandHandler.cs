using Application.Abstractions.Auth.UserManagerS;
using Application.Message;
using Gatherly.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.UserManager
{
    public class RemoveRoleFromUserCommandHandler : ICommandHandler<RemoveRoleFromUserCommand, Result<string>>
    {
        private readonly IUserManagerServices _roleManagerServices;

        public RemoveRoleFromUserCommandHandler(IUserManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        public async Task<Result<string>> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            return await _roleManagerServices.RemoveRoleFromUser(request.username, request.rolename);
        }
    }
}


