using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Group.Command;

public record EditGroupDto(Guid Id, string Name, Guid BatchId) : ICommand<Result<string>>;




