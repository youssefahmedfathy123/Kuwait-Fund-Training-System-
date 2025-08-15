using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Honor
{
    public interface IHonorServices
    {
        Task<string> Create(CreateHonorDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateHonorDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<HonorDto>> Read(CancellationToken cancletionToken);
    }
}


