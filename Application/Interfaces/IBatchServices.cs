using Application.EntitiesOperations.Batch.Command;
using Application.EntitiesOperations.Batch.Query;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBatchServices
    {
        Task<string> Create(CreateBatchDto input, CancellationToken cancellationToken);
        Task<List<BatchDto>> Read();
        Task<Result<string>> Update(EditBatchDto input, CancellationToken cancellationToken);
        Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
        
    }
}



