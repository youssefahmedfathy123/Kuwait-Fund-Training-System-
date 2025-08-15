using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Batch.Command
{
    public sealed class DeleteBatchHandler : ICommandHandler<DeleteBatch,Result<string>>
    {
        private readonly IBatchServices _batchServices;
        public DeleteBatchHandler(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }
        public async Task<Result<string>> Handle(DeleteBatch request, CancellationToken cancellationToken)
        {
            return await _batchServices.Delete(request.id, cancellationToken);
        }
    }
}

