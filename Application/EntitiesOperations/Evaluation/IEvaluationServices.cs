using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Evaluation
{
    public interface IEvaluationServices
    {
        Task<string> Create(CreateEvaluationDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateEvaluationDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<EvaluationDto>> Read(CancellationToken cancletionToken);

        Task<string> AddOrEditEvaluation(int Id, int value, CancellationToken cancletionToken);

        Task<string> AddOrEditExamResult(int Id, int value, CancellationToken cancletionToken);

    }
}




