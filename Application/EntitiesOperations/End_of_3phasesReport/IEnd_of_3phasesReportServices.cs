using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.End_of_3phasesReport
{
    public interface IEnd_of_3phasesReportServices
    {
        Task<string> Create(CreateEnd_of_3phasesReportWithFileDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateEnd_of_3phasesReporFiletDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<End_of_3phasesReportDto>> Read(CancellationToken cancletionToken);
        Task<Domain.Entities.End_of_3phasesReport> FindById(Guid Id, CancellationToken cancletionToken);

    }
}





