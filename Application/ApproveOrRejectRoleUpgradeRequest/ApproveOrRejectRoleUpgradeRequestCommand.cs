using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.ApproveOrRejectRoleUpgradeRequest;
public sealed record ApproveOrRejectRoleUpgradeRequestCommand(
    Guid RequestId,
    bool IsApproved
    ) : ICommand<Result<string>>;



