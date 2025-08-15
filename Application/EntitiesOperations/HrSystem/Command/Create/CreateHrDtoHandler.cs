using Application.Common;
using Application.Message;
using Gatherly.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.HrSystem.Command.Create
{
    public sealed class CreateHrDtoHandler : ICommandHandler<CreateHrDto, Result<Guid>>
    {
        private readonly IHrsystemServices _hrServices;
        public CreateHrDtoHandler(IHrsystemServices hrServices)
        {
            _hrServices = hrServices;
        }
        public async Task<Result<Guid>> Handle(CreateHrDto request, CancellationToken cancellationToken)
        {
            
            return await _hrServices.Create(request,cancellationToken);

        }
    }
}




