using Application.Common;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.HrSystem.Command.Update
{
    public class EditHrDtoHandler : ICommandHandler<EditHrDto, Result<string>>
    {
        private readonly IHrsystemServices _hrServices;
        public EditHrDtoHandler(IHrsystemServices hrServices)
        {
            _hrServices = hrServices;
        }
        public async Task<Result<string>> Handle(EditHrDto request, CancellationToken cancellationToken)
        {
            return await _hrServices.Update(request,cancellationToken);
        }
    }
}


