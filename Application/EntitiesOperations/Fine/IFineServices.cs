using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Fine
{
    public interface IFineServices
    {
        Task<string> Create(CreateFineDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateFineDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<FineDto>> Read(CancellationToken cancletionToken);
    }
}




