using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Waiting
{
    public interface IWaitingServices
    {
        Task<string> Create(CreateWaitingDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateWaitingDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<WaitingDto>> Read(CancellationToken cancletionToken);
    }
}


