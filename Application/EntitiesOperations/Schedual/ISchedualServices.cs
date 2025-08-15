using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Schedual
{
    public interface ISchedualServices
    {
        Task<string> Create(CreateSchedualDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateSchedualDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<SchedualDto>> Read(CancellationToken cancletionToken);
    }
}



