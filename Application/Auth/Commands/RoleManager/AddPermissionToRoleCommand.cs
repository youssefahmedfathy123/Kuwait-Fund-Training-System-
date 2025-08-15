using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.Auth.Commands.RoleManager;
    public sealed record AddPermissionToRoleCommand(
        string RoleName,
        string PermissionName
        ) : ICommand<Result<string>>;
    

    



