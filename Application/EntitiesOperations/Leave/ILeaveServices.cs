using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Leave
{
    public interface ILeaveServices
    {
        Task<string> Create(IFormFile? file, LeavePropertiesWithoutPdf leave, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateLeaveFileDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<LeaveDto>> Read(CancellationToken cancletionToken);
        Task<Result<string>> Approve(
        Guid LeaveId,
        LeaveStatus status,
        CancellationToken cancellationToken);

        Task<Domain.Entities.Leave> FindById(Guid Id, CancellationToken cancletionToken);

    }
}


