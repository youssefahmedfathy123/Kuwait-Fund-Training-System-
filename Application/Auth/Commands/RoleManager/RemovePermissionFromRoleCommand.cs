using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.Auth.Commands.RoleManager;
    public sealed record RemovePermissionFromRoleCommand(
        string RoleName,
        string PermissionName
        ) : ICommand<Result<string>>;


