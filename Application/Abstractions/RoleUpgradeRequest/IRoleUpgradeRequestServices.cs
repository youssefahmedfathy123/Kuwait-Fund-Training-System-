using Gatherly.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Abstractions.RoleUpgradeRequest
{
    public interface IRoleUpgradeRequestServices
    {
        Task<Result<string>> Add(string userId,string RequestRole,CancellationToken Cancellation);
        Task<Result<string>> ApproveOrReject(Guid RequestId, bool IsApproved, CancellationToken Cancellation);

    }
}




