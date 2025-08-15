using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Trainee
{
    public interface ITraineeServices
    {
        Task<string> Create(CreateTraineeDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(EditTraineeDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTrainee input, CancellationToken cancletionToken);
        Task<List<TraineeDto>> Read(CancellationToken cancletionToken);
    }
}





