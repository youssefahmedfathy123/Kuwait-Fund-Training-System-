using Application.EntitiesOperations.Honor;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Message
{
    public interface IMessageServices
    {
        Task<string> Create(CreateMessageDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateMessageDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<MessageDto>> Read(CancellationToken cancletionToken);
    }
}



