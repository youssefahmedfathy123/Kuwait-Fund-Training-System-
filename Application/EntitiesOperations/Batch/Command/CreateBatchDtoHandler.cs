using Application.Interfaces;
using Application.Message;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Batch.Command
{
    public sealed class CreateBatchDtoHandler : ICommandHandler<CreateBatchDto, string>
    {
        private readonly IBatchServices _batchServices;
        public CreateBatchDtoHandler(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }
        public async Task<string> Handle(CreateBatchDto request, CancellationToken cancellationToken)
        {
            return await _batchServices.Create(request, cancellationToken);
        }
    }
}



