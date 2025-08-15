using Application.EntitiesOperations.Attendance;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Exam
{
    public interface IExamServices
    {
        Task<string> Create(CreateExamDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateExamDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<ExamDto>> Read(CancellationToken cancletionToken);
    }
}


