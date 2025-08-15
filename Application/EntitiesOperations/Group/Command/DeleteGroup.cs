using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Group.Command;

public record DeleteGroup(
       Guid Id
    ) :  ICommand<Result<Guid>>;


