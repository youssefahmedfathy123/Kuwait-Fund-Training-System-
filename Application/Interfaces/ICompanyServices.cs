using Application.EntitiesOperations.Company.Command;
using Application.EntitiesOperations.Company.Query;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICompanyServices
    {
            Task<string> Create(CreateCompanyDto input, CancellationToken cancellationToken);
            Task<List<CompanyDto>> Read(CancellationToken cancellationToken);
            Task<Result<string>> Update(EditCompanyDto input, CancellationToken cancellationToken);
            Task<Result<string>> Delete(DeleteCompany delete, CancellationToken cancellationToken);


    }
}
