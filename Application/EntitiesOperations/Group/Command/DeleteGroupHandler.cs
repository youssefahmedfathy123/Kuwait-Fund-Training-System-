using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Group.Command
{
    public class DeleteGroupHandler : ICommandHandler<DeleteGroup, Result<Guid>>
    {
        private readonly IGroupServices _groupServices;
        public DeleteGroupHandler(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }
        public async Task<Result<Guid>> Handle(DeleteGroup request, CancellationToken cancellationToken)
        {
            return await _groupServices.Delete(request, cancellationToken);
        }
    }
}



