using Application.Interfaces;
using Application.Message;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Group.Command
{
    public class CreateGroupDtoHandler : ICommandHandler<CreateGroupDto, string>
    {
        private readonly IGroupServices _groupServices;
        public CreateGroupDtoHandler(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }
        public async Task<string> Handle(CreateGroupDto request, CancellationToken cancellationToken)
        {
           return await _groupServices.Create(request, cancellationToken);
        }
    }
}


