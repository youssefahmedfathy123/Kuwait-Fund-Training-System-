using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Bi_weeklyReport
{
    public interface IBi_weeklyReportServices
    {
        Task<string> Create(CreateBi_weeklyReportDtoWithoutPdfAndUserIdDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateBi_weeklyReportFileDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<Bi_weeklyReportDto>> Read(CancellationToken cancletionToken);
        Task<Domain.Entities.Bi_weeklyReport> FindById(Guid Id, CancellationToken cancletionToken);

    }
}



