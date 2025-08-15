using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Group.Command;

public class EditGroupDtoHandler : ICommandHandler<EditGroupDto, Result<string>>
{
    private readonly IGroupServices _groupServices;
    public EditGroupDtoHandler(IGroupServices groupServices)
    {
        _groupServices = groupServices;
    }
    public async Task<Result<string>> Handle(EditGroupDto request, CancellationToken cancellationToken)
    {
        return await _groupServices.Update(request, cancellationToken);
    }
}
     



