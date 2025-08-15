using Application.Message;
using Gatherly.Domain.Shared;
using MediatR;

namespace Application.Auth.Queries.LoginOperation;
    public sealed record LoginCommand(
        string Email,
        string Password
        ) : IQuery<Result<string>>;




