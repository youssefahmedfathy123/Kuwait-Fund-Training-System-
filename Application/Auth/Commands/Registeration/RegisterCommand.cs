using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.Auth.Commands.Registeration;

    public sealed record RegisterCommand(
        string Name,
        string Email,
        string UserName,
        string Password,
        Roles role
        ) : ICommand<Result<string>>;







