using Application.Message;
using Gatherly.Domain.Shared;

namespace Application.RoleUpgradeRequest;
    public sealed record RoleUpgradeRequestCommand(
        string userId,
        string requestedRole
        )
    : ICommand<Result<string>>;


