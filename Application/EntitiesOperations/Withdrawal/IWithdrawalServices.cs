using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Withdrawal
{
    public interface IWithdrawalServices
    {
        Task<string> Create(CreateWithdrawalFileDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateWithdrawalFileDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<WithdrawalDto>> Read(CancellationToken cancletionToken);
        Task<Result<string>> ApproveOrReject(Guid WithdrawalId, LeaveStatus status, CancellationToken cancletionToken);

    }
}


