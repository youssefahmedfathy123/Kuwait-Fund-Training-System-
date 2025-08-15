using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Cource
{
    public interface ICourceServices
    {
        Task<string> Create(CreateCourceDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(EditCourceDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteCource input, CancellationToken cancletionToken);
        Task<List<CourceDto>> Read(CancellationToken cancletionToken);
    }
}




