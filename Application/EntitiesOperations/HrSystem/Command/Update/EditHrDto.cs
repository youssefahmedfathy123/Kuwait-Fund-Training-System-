using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.HrSystem.Command.Update
{
    public record EditHrDto(
       Guid Id, string NationalId, string Name, DateTime BirthDate
        ) : ICommand<Result<string>>;
}


