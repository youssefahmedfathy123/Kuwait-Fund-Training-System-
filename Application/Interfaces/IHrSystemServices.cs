using Application.EntitiesOperations.HrSystem.Command.Create;
using Application.EntitiesOperations.HrSystem.Command.Delete;
using Application.EntitiesOperations.HrSystem.Command.Update;
using Application.EntitiesOperations.HrSystem.Query.Read;
using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common
{
    public interface IHrsystemServices
    {
        Task<Result<Guid>> Create(CreateHrDto input, CancellationToken cancellationToken);
        Task<Result<string>> Update(EditHrDto input, CancellationToken cancellationToken);
        Task<Result<string>> Delete(DeleteFromHrSystem input, CancellationToken cancellationToken);
        Task<List<HrDto>> Read();


    }
}




