using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Feedback
{
    public interface IFeedbackServices
    {
        Task<string> Create(CreateFeedbackDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateFeedbackDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<FeedbackDto>> Read(CancellationToken cancletionToken);
    }
}


