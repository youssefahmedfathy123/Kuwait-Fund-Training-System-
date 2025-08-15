using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.HrSystem.Command.Create
{
    public record CreateHrDto(
         string NationalId, string Name, DateTime BirthDate
        ) :ICommand<Result<Guid>>;
    
    
}




