using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Trainer
{
    public interface ITrainerServices
    {
        Task<string> Create(CreateTrainerDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateTrainerDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTrainer input, CancellationToken cancletionToken);
        Task<List<TrainerDto>> Read(CancellationToken cancletionToken);
    }
}




