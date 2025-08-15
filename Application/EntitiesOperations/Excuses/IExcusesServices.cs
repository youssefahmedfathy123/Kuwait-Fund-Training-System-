using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Excuses
{
    public interface IExcusesServices
    {
        Task<string> Create(CreateExcusesFileDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateExcusesFileDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<ExcusesDto>> Read(CancellationToken cancletionToken);
        Task<Result<string>> ApproveOrReject(Guid ExcusesId, Aggrement status, CancellationToken cancletionToken);

    }
}




