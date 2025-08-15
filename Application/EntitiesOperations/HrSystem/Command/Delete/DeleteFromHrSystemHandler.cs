using Application.Common;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.HrSystem.Command.Delete
{
    public class DeleteFromHrSystemHandler : ICommandHandler<DeleteFromHrSystem, Result<string>>
    {
        private readonly IHrsystemServices _hrServices;
        public DeleteFromHrSystemHandler(IHrsystemServices hrServices)
        {
            _hrServices = hrServices;
        }
        public async Task<Result<string>> Handle(DeleteFromHrSystem request, CancellationToken cancellationToken)
        {
            return await _hrServices.Delete(request,cancellationToken);
        }
    }
}
