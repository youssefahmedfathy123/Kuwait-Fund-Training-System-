using Application.EntitiesOperations.Group.Command;
using Application.EntitiesOperations.Group.Query;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGroupServices
    {
        Task<string> Create(CreateGroupDto input,CancellationToken cancletionToken);
        Task<Result<string>> Update(EditGroupDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteGroup input, CancellationToken cancletionToken);
        Task<List<GroupDto>> Read(CancellationToken cancletionToken);


    }
}


