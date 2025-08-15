using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.HrSystem.Command.Delete;

public record DeleteFromHrSystem(
       Guid Id
    )
    :ICommand<Result<string>>;

