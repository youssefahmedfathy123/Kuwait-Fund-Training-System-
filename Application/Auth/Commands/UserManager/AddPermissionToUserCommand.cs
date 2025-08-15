using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.Auth.Commands.UserManager;
    public sealed record AddPermissionToUserCommand(
       string username,
       string permissionName
        ) : ICommand<Result<string>>;


