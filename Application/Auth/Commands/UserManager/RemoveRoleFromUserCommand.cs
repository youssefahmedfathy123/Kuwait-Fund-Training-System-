using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.Auth.Commands.UserManager;
    public sealed record RemoveRoleFromUserCommand(
        string rolename,
        string username
        ) : ICommand<Result<string>>;



