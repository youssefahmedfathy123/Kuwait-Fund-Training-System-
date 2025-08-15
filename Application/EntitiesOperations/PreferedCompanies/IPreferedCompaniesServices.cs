using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.PreferedCompanies
{
    public interface IPreferedCompaniesServices
    {
        Task<string> Create(CreatePreferedCompaniesDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdatePreferedCompaniesDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<PreferedCompaniesDto>> Read(CancellationToken cancletionToken);
    }
}





