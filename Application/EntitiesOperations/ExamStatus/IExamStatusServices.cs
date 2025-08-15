using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.ExamStatus
{
    public interface IExamStatusServices
    {
        Task<string> Create(CreateExamStatusDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateExamStatusDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<ExamStatusDto>> Read(CancellationToken cancletionToken);
        Task<List<Domain.Entities.Trainee>> TopTwo(Guid Id, CancellationToken cancletionToken);

    }
}



