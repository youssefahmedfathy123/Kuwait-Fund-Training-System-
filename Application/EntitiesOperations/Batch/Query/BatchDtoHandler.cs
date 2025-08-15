using Application.Interfaces;
using Application.Message;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Batch.Query
{
    internal class BatchDtoHandler : ICommandHandler<GetAllBatches, List<BatchDto>>
    {
        private readonly IBatchServices _batchServices;
        public BatchDtoHandler(IBatchServices batchServices)
        {
            _batchServices = batchServices;
        }
        public async Task<List<BatchDto>> Handle(GetAllBatches request, CancellationToken cancellationToken)
        {
            return await _batchServices.Read();
        }
    }
}



