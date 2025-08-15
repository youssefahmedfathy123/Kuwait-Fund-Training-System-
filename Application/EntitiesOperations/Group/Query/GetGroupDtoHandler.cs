using Application.Auth.Commands.UserManager;
using Application.Interfaces;
using Application.Message;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Group.Query
{
    public class GetGroupDtoHandler : ICommandHandler<GetAllGroups, List<GroupDto>>
    {
        private readonly IGroupServices _groupServices;
        public GetGroupDtoHandler(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }
        public async Task<List<GroupDto>> Handle(GetAllGroups request, CancellationToken cancellationToken)
        {
            return await _groupServices.Read(cancellationToken);
        }
    }
}

