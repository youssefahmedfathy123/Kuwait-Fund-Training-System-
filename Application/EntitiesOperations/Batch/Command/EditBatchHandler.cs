using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Batch.Command
{
    public sealed class EditBatchDtoHandler : ICommandHandler<EditBatchDto, Result<string>>
    {
        private readonly IBatchServices _batchServices;
        public EditBatchDtoHandler(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }
        public async Task<Result<string>> Handle(EditBatchDto request, CancellationToken cancellationToken)
        {
            return await _batchServices.Update(request, cancellationToken);
        }
    }
}




